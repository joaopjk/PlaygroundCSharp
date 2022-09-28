using System;
using static System.Console;

namespace Reflections
{
  static class Program
  {
    static void Main(string[] _)
    {
      // System.Type
      Type t = typeof(int);
      foreach (var method in t.GetMethods())
        WriteLine(method);

      Type t2 = "hello".GetType();
      WriteLine(t2.Name);
      WriteLine(t2.FullName);

      var a = typeof(string).Assembly;
      WriteLine(a.FullName);

      var types = a.GetTypes();
      WriteLine(types[0]);

      var t3 = Type.GetType("System.Int64");
      WriteLine(t3.FullName);

      var t4 = Type.GetType("System.Collections.Generic.List`1");
      WriteLine(t4.FullName);
      // WriteLine(t4.GetFields()[0]);

      // Inspection
      var t5 = typeof(Guid);
      var ctors = t5.GetConstructors();
      WriteLine(ctors);

      foreach (var ctor in ctors)
      {
        var pars = ctor.GetParameters();
        for (var i = 0; i < pars.Length; ++i)
        {
          WriteLine(pars[i].Name);
          WriteLine(pars[i].ParameterType.Name);
        }
      }

      // Construction
      var t6 = typeof(bool);
      var b = Activator.CreateInstance(t6);
      WriteLine(b);

      var b2 = Activator.CreateInstance<bool>();
      WriteLine(b2);

      var wc = Activator.CreateInstance("System", "System.Timers.Timer");
      WriteLine(wc.Unwrap());

      var alType = Type.GetType("System.Collections.ArrayList");
      WriteLine(alType.Name);

      var alCtor = alType.GetConstructor(Array.Empty<Type>());
      WriteLine(alCtor);

      var al = alCtor.Invoke(Array.Empty<object>());
      WriteLine(al);

      var st = typeof(string);
      var stCtor = st.GetConstructor(new[] { typeof(char[]) });
      WriteLine(stCtor);

      var str = stCtor.Invoke(new object[] { new[] { 't', 'e', 's', 't' } });
      WriteLine(str);

      var listType = Type.GetType("System.Collections.Generic.List`1");
      WriteLine(listType);

      var listOfIntType = listType.MakeGenericType(typeof(int));
      WriteLine(listOfIntType);

      var listOfIntCtor = listOfIntType.GetConstructor(Array.Empty<Type>());
      WriteLine(listOfIntCtor);

      var theList = listOfIntCtor.Invoke(Array.Empty<object>());
      WriteLine(theList);

      var charType = typeof(char);
      Array.CreateInstance(charType, 10);

      var charArrayType = charType.MakeArrayType();
      WriteLine(charArrayType);

      var charArrayCtor = charArrayType.GetConstructor(new[] { typeof(int) });
      WriteLine(charArrayCtor);

      var arr = charArrayCtor.Invoke(new object[] { 20 });
      WriteLine(arr);

      char[] arr2 = (char[])arr;
      WriteLine(arr2);

      //Invocation
      const string s = "abracadabra  ";
      t = typeof(string);
      WriteLine(t);
      var trimMethod = t.GetMethod("Trim", Array.Empty<Type>());
      var result = trimMethod.Invoke(s, Array.Empty<object>());
      WriteLine(result);

      var parseMethod = typeof(int).GetMethod(
        "TryParse",
        new[] { typeof(string), typeof(int).MakeByRefType() });
      object[] args = { "123", null };
      var ok = parseMethod.Invoke(null, args);
      WriteLine(ok);

      var at = typeof(Activator);
      var atMethod = at.GetMethod("CreateInstance", Array.Empty<Type>());
      var ciGeneric = atMethod.MakeGenericMethod(typeof(Guid));
      var guid = ciGeneric.Invoke(null, null);
      WriteLine(guid);
    }
  }
}
