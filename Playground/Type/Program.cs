using System;
using static System.Console;

namespace SystemType
{
    internal class Program
    {
        static void Main(string[] _)
        {
            #region Reflection
            Type t = typeof(int);
            foreach (var item in t.GetMethods())
            {
                Write(item.Name + " | ");
                foreach (var item2 in item.GetParameters())
                {
                    Write(item2.Name + " | " + item2.GetType() + ",");
                }
                Write(item.DeclaringType + " | ");
                Write(item.ReturnParameter + " | ");
                WriteLine();
            }

            Type t2 = "hello".GetType();
            Write(t2.FullName);
            foreach (var item in t2.GetFields())
            {
                Write(item.Name + " | " + item.GetType());
            }

            var a = typeof(string).Assembly;
            Write(a.FullName);
            foreach (var item in a.GetTypes())
            {
                Write(item.FullName);
            }
            var t3 = Type.GetType("System.Int64");
            Write(t3.FullName);
            #endregion
            #region Inspection
            WriteLine();
            var t5 = typeof(Guid);
            WriteLine(t5.FullName);
            var ctors = t5.GetConstructors();
            foreach (var item in ctors)
            {
                WriteLine(item.Name);

                foreach (var param in item.GetParameters())
                {
                    Write($"{param.ParameterType.Name} - {param.Name}");
                }
            }

            var methos = t5.GetMethods();
            foreach (var method in methos)
            {
                WriteLine(method.Name);
            }
            #endregion
            #region Constructor
            t = typeof(bool);
            var b = Activator.CreateInstance(t);
            WriteLine(b);
            var b2 = Activator.CreateInstance<bool>();
            WriteLine(b2);
            var wc = Activator.CreateInstance("System", "System.Timers.Timer");
            wc.Unwrap();
            var altype = Type.GetType("System.Collections.ArrayList");
            WriteLine(altype);
            var alCtor = altype.GetConstructor(Array.Empty<Type>());
            var al = alCtor.Invoke(Array.Empty<object>());
            WriteLine(al);
            var st = typeof(string);
            var ctor = st.GetConstructor(new[] { typeof(char[]) });
            WriteLine(ctor);
            var str = ctor.Invoke(new object[]
            {
                new []{'t','e','s','t'}
            });
            WriteLine(str);
            var listType = Type.GetType("System.Collections.Generic.List`1");
            WriteLine(listType);
            var listOfIntType = listType.MakeGenericType(typeof(int));
            WriteLine(listOfIntType);
            var listOfIntCtor = listOfIntType.GetConstructor(Array.Empty<Type>());
            WriteLine(listOfIntCtor);
            var theList = listOfIntCtor.Invoke(Array.Empty<object>());
            Write(theList);
            var charType = typeof(char);
            #endregion
        }
    }
}
