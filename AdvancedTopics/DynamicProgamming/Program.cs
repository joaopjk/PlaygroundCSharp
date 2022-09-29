using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;
using System.Xml.Linq;
using Microsoft.CSharp.RuntimeBinder;
using static System.Console;

namespace DynamicProgamming
{
  static class Program
  {
    class Widget : DynamicObject
    {
      public void WhatIsThis()
      {
        WriteLine(This.World);
      }

      public dynamic This => this;

      public override bool TryGetMember(GetMemberBinder binder, out object result)
      {
        result = binder.Name;
        return true;
      }

      public override bool TryGetIndex(GetIndexBinder binder, object[] indexes, out object result)
      {
        if (indexes.Length == 1)
        {
          result = new string('*', (int)indexes[0]);
          return true;
        }

        result = null;
        return false;
      }
    }

    class DynamicXmlNode : DynamicObject
    {
      private readonly XElement node;

      public DynamicXmlNode(XElement node)
      {
        this.node = node;
      }

      public override bool TryGetMember(GetMemberBinder binder, out object result)
      {
        var element = node.Element(binder.Name);
        if (element != null)
        {
          result = new DynamicXmlNode(element);
          return true;
        }
        else
        {
          var attribute = node.Attribute(binder.Name);
          if (attribute != null)
          {
            result = attribute.Value;
            return true;
          }
          else
          {
            result = null;
            return false;
          }
        }
      }
    }

    abstract class Expression { }

    class Literal : Expression
    {
      public double Value { get; }

      public Literal(double value)
      {
        Value = value;
      }
    }

    class Addition : Expression
    {
      public Expression Left { get; }
      public Expression Right { get; }

      public Addition(Expression left, Expression right)
      {
        Left = left;
        Right = right;
      }
    }

    static class ExpressionPrinter
    {
      public static void Print(Literal literal, StringBuilder sb)
      {
        sb.Append(literal.Value);
      }
    }

    static void Main(string[] _)
    {
      // late binding
      dynamic d = "hello";
      WriteLine(d.GetType());
      WriteLine(d.Length);
      d += " world";
      WriteLine(d);

      try
      {
        int n = d.Area;
      }
      catch (RuntimeBinderException e)
      {
        WriteLine(e.Message);
      }

      d = 32;
      WriteLine(d.GetType());

      var w = new Widget() as dynamic;
      WriteLine(w.Hello);
      WriteLine(w[7]);

      const string xml = "<people><person name='Joao'/></people>";
      var node = XElement.Parse(xml);
      var name = node.Element("person").Attribute("name");
      WriteLine(name?.Value);

      dynamic dyn = new DynamicXmlNode(node);
      WriteLine(dyn.person.name);

      // Expand objects
      dynamic person = new ExpandoObject();
      person.FirstName = "Joao";
      person.Age = 28;
      WriteLine(person.FirstName + person.Age);

      person.Address = new ExpandoObject();
      person.Address.City = "London";
      person.Address.Country = "UK";
      WriteLine(person.Address.City + person.Address.Country);

      person.SayHello = new Action(() => WriteLine("Hello"));
      person.SayHello();

      person.Falls = null;
      person.Falls += new EventHandler<dynamic>((_, args) => WriteLine(args));

      EventHandler<dynamic> c = person.Falls;
      c?.Invoke(person, person.FirstName);

      var dict = (IDictionary<string, object>)person;
      WriteLine(dict.ContainsKey("FirstName"));
      WriteLine(dict.ContainsKey("LastName"));

      dict["LastName"] = "Sousa";
      WriteLine(dict.ContainsKey("LastName"));
      WriteLine(person.LastName); // Works

      // Dynamic Visition
      var adt = new Addition(
        new Addition(
          new Literal(1),
          new Literal(2)
        ),
        new Literal(3)
      );
    }
  }
}
