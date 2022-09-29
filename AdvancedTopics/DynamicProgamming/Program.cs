using System.Dynamic;
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
    }
  }
}
