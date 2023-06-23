using System.Collections;
using System.Diagnostics;

namespace CollectionsGenerics
{
    /*
         * - Closely related data can be handled more efficiently when grouped together into a
         * collection. Instead of writing separete code to handle each individual object, you 
         * can use the same code to process all the elements of a collection.
         * - A collection is a set of similarly typed objects that are grouped together. A 
         * collection is an object by itself, which would be manage other objects eg: ArrayList,
         * HashTable, Stack, Queue, LinkedList, SortedList, etc.
         * - Collection classes are defined as part of the System.Collections and System.Collections.
         * Generics namespace.
         * - Most collection classes derive from the interfaces ICollection, IComparer, IEnumerable,
         * IList, IDictionary and IDictionaryEnumerator and ther generic equivalents.
         * 
         * - Benefits
         * 1. Build-in sorting cabailities
         * 2. Most of them are automatically indexed to give best peformance
         * 3. Memory management is handled automatically and capacity of a collection is expanded as
         * required
         * 4. Synchronization provides thread safety when accessing members of the collection
         * 5. Collections classes can generate wrappers that make the collection read-olny or fixed-size
         * 6. Collections class can generate its own enumerator that makes it easy to iterate throug the
         * elements
         * 
         * ArrayList
         * - Implements the IList interface using an array whose size is dynamically incresed as required
         * - The capacity of an arraylist is the number of elements the arraylist can hold. The default
         * initial capacity for an arrayList is 0. As elements are added to an arraylist, the capacity is
         * automatically increased as required through reallocation with the default capacity on adding first
         * item set to 4. The capacity can be decreased by calling TrimToSize or by setting the capacity
         * property explicitly.
         * - Elements in this collection can be accesses using an intenger index.
         * - Arrayslist accepts a null reference(nothing in Visual Basic) as a valid value and allows duplicate
         * elements.
         * - If we look for information based on index, the we use ArrayList.
         * 
         * HashTable
         * - Represents a collection of key/value pairs that are organized based on the hash code of the key.
         * - Each element is a key/value pair stored in a DictionaryEnty object. A key cannot be a null reference
         * , a value can be.
         * - The capacity of a Hashtable is the number of elements the hashtable can hold. The default initial 
         * capacity for a hashtable is 0. As elements are added to a hashtable, the capacity is automatically 
         * increased as require through reallocation with the default capacity on adding first item set to 4.
         * - In hashtable key must be unique but value need not be unique.
         * 
         * SortedList
         * - Is similar to the hashtable class in that they implements the IDictionary interface, but they maintain
         * ther elements in sort order by key. The properties that return keys and values are indexed, allowing
         * efficient indexed retrieval
         * 
         * Queue and Stack
         * - Are useful when you need temporary storage for information, that is, when you might want to discard an
         * elements after retrieving its value. Use queue if you need to access the information in the same order 
         * that it is stored in the collection. Use stack if you need to access the information in reverse order.
         * 
         * BitArray
         * - Bit collections are collections whose elements are bit flags. Because each element is a bit instead of
         * an object, these collections behave slightly differently from other collections. The bitarray is a collection
         * class in whici the capacity is always the same as the count. Elements are added to a bitarray by increasing
         * the lenght property, elements are deleted by decreasing the length property.
         */
    internal class Program
    {
        static void Main(string[] _)
        {
            ArrayList al = new(100) { 1, 2, 3, 4, "3", false, true };
            Console.WriteLine(al.Add(100));
            al.AddRange(new string[] { "1", "2", "3" });
            al.Insert(2, 34);
            al.Remove(1);
            al.Remove("1");
            al.RemoveAt(0);
            //al.Sort(); Don't work in array with different data types

            Console.WriteLine(al.Capacity + " " + al.Count);

            al.TrimToSize();
            Console.WriteLine(al.Capacity + " " + al.Count);

            al.ToArray().ToList().ForEach(x => Console.WriteLine(x));
            Console.WriteLine("Second foreach");
            foreach (var x in al) Console.WriteLine(x);

            //string[] ar = (string[])al.ToArray(typeof(string)); Don't work in array with different data types
        }
    }

    class HashTableProgram
    {
        static void Main(string[] _)
        {
            Hashtable ht = new()
            {
                { 101, "S1" },
                { 102, "S2" },
                { 103, "S3" },
                { 104, "S4" },
                { 105, "S5" },
                { 106, "S6" }
            };
            ht.Remove(103);
            string value = ht[101]?.ToString();
            Console.WriteLine(value);

            foreach (DictionaryEntry item in ht)
            {
                Console.WriteLine($"Key: {item.Key} - Value: {item.Value}");
            }
        }
    }

    class SortedListProgram
    {
        static void Main(string[] _)
        {
            SortedList sl = new()
            {
                { 101, "S1" },
                { 102, "S2" },
                { 103, "S3" },
                { 104, "S4" },
                { 105, "S5" },
                { 106, "S6" }
            };
            sl.Remove(103);
            string value = sl[101]?.ToString();
            Console.WriteLine(value);

            foreach (DictionaryEntry item in sl)
            {
                Console.WriteLine($"Key: {item.Key} - Value: {item.Value}");
            }

            Console.WriteLine(sl.GetByIndex(101).ToString());
            Console.WriteLine(sl.GetKey(101));
        }
    }

    class Employee : IComparable
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int CompareTo(object other)
        {
            Employee obj = (Employee)other;

            if (this.Id > obj.Id) return 1;
            else if (this.Id < obj.Id) return -1;
            return 0;
        }

        public override string ToString()
        {
            return $"Id: {Id} - Name: {Name}";
        }
    }

    class EmployeeComparer : IComparer
    {
        public int Compare(object x, object y)
        {
            Employee objX = (Employee)x;
            Employee objY = (Employee)y;

            //if (objX.Id > objY.Id) return 1;
            //else if (objX.Id < objY.Id) return -1;
            //return 0;

            return objX.Id - objY.Id;
        }
    }

    class EmployeeCollectionProgram
    {
        static void Main(string[] _)
        {
            var watch = new Stopwatch();

            ArrayList alEmp = new()
            {
                new Employee() { Id = 1, Name = "E1" },
                new Employee() { Id = 2, Name = "E2" },
                new Employee() { Id = 3, Name = "E3" },
                new Employee() { Id = 4, Name = "E4" }
            };

            watch.Start();
            foreach (Employee employee in alEmp)
            {
                Console.WriteLine(employee.ToString());
            }
            watch.Stop();
            Console.WriteLine(watch.ElapsedMilliseconds);

            IEnumerator en = alEmp.GetEnumerator();

            watch.Restart();
            while (en.MoveNext())
            {
                /*
                 Propriedades BOF, EOF:
                - BOF indica que a posição atual do registro é antes do primeiro registro em um objeto Recordset
                - EOF indica que a posição do registro atual é depois do último registro em um objeto Recordset.
                 */
                Employee employee = (Employee)en.Current;
                Console.WriteLine(employee);
            }
            watch.Stop();
            Console.WriteLine(watch.ElapsedMilliseconds);

            alEmp.Sort(new EmployeeComparer());
            foreach (Employee employee in alEmp)
            {
                Console.WriteLine(employee.ToString());
            }

            alEmp.Reverse();
        }
    }

    /*
        Generics
    - Generics introduce to the .Net Framework the concept of type parameters, which make it possible to design classes and methods
    that defer the specification of one or more types until the class or method is declared and instantiated by client code. For
    example, by using a generic type parameter T you can writ a single class that other client code can user without incurring the
    cost or risk of runtime casts or boxing operations, as show here:
    - A Generic Class is not specific to any particular Data type. But the instance of such a class would be specific to a given 
    Data type mentioned at the time of creanting the instance/object that class.
    - Generic collection classes are like Templates in C++. At the implementation level, the primary difference is that C# generic
    type substituitions are performed at runtime and generic type information is thereby preserved for instantiated objects.

        Advantages of Generics
    - Type Safety: Generic types enforce type compliance at compile-time, and not run-time(as in the case of using Object). This
    reduce the chances of data-type conflict during run-time.
    - Peformance: The data types to be used in a Generic class are determined at compile-time, hence there is no need to perform type
    casting(boxing and unboxing) during run-time, which is a computationally constly process.
    - Code reuse: Since you only need to write the class once and customize it to use with the various data types, there is a 
    substantial amount of code-reuse.


        Tips
    - When a generic type is first constructed with a value type as a parameter, the runtime creates a specializes generic type with
    the supplied parameter substituted the appropriate places in the MSIL. Specialiez generic types are created once for each unique
    value type used as a parameter.
    - If at another point in your program code another GenericsList<T> class is created, this time with a different valu type such
    as a long the runtime generates another version of the generic type, this time substituting a long in the appropriate place in
    MSIL. Conversions are no longer necessary because each specialized generic class natively contains the value type.
     */

    class Stack
    {
        readonly int[] data;
        int top = -1;
        public Stack(int size)
        {
            data = new int[size];
        }

        public void Push(int value)
        {
            if (top < data.Length - 1)
            {
                top++;
                data[top] = value;
            }
            else
            {
                Console.WriteLine("Não é possível mais adicionar elementos a Stack");
            }
        }

        public int Pop()
        {
            if (top > -1)
            {
                int value = data[top];
                data[top] = 0;
                top--;
                return value;
            }
            throw new ArgumentOutOfRangeException();
        }

        public int GetTopElement()
        {
            if (top > -1)
            {
                return data[top];
            }
            throw new ArgumentOutOfRangeException();
        }

        public void Prinf()
        {
            IEnumerator enumerator = data.GetEnumerator();
            while (enumerator.MoveNext())
            {
                Console.WriteLine((int)enumerator.Current);
            }
            Console.WriteLine();
        }
    }

    class Stack<T> where T : struct
    {
        readonly T[] data;

        int top = -1;
        public Stack(int size)
        {
            data = new T[size];
        }

        public void Push(T value)
        {
            if (top < data.Length - 1)
            {
                top++;
                data[top] = value;
            }
            else
            {
                Console.WriteLine("Não é possível mais adicionar elementos a Stack");
            }
        }

        public T Pop()
        {
            if (top > -1)
            {
                var value = data[top];
                data[top] = default;
                top--;
                return value;
            }
            throw new ArgumentOutOfRangeException();
        }

        public T GetTopElement()
        {
            if (top > -1)
            {
                return data[top];
            }
            throw new ArgumentOutOfRangeException();
        }

        public void Prinf()
        {
            IEnumerator enumerator = data.GetEnumerator();
            while (enumerator.MoveNext())
            {
                Console.WriteLine((T)enumerator.Current);
            }
            Console.WriteLine();
        }
    }

    class StackMain
    {
        static void Main(string[] _)
        {
            Console.Clear();

            Stack stack = new(5);
            stack.Push(5);
            stack.Push(12);
            stack.Push(14);
            stack.Push(22);
            stack.Push(134);

            stack.Push(1222);

            stack.Prinf();
            stack.Pop();
            stack.Push(1222);
            stack.Prinf();

            var stackGenericsDouble = new Stack<double>(5);
            var stackGenericsDouble1 = new Stack<double>(5);

            Console.WriteLine(stackGenericsDouble.GetType().GetHashCode());//  The same address memory
            Console.WriteLine(stackGenericsDouble1.GetType().GetHashCode());// The same address memory

            stackGenericsDouble.Push(5.1);
            stackGenericsDouble.Push(12.123);
            stackGenericsDouble.Push(14.22);
            stackGenericsDouble.Push(22.12);
            stackGenericsDouble.Push(134.12);

            stackGenericsDouble.Push(1222);

            stackGenericsDouble.Prinf();
            stackGenericsDouble.Pop();
            stackGenericsDouble.Push(1222);
            stackGenericsDouble.Prinf();

            //var stackEmp = new Stack<Employee>(5); Don't work. Stack can be create only with struct types
        }
    }

    /*
        Unbounded Type Parameters
    Type parameters that have no constraints, such as T in public class SamplesClass<T>, are called unbounded type parameters.
    Unbounded type parameters have the following rules:
    - The != and == operators cannot be used because the is no guarantee that the concrete type arguments will suport these operators
    - They can be converted to and from System.Object or explicitly converted to any interface type
    - You can compare to null. If an unbounded parameter is compared to null, the comparison will always return false if the type
    argument if the type argument is a value type.
     */

    class Demo
    {
        static void Swap<T>(ref T lhs, ref T rhs) where T: struct
        {
            T temp;
            temp = lhs;
            lhs = rhs;
            rhs = temp;
        }
        static void Main(string[] _)
        {
            int a = 1;
            int b = 2;

            Swap<int>(ref a, ref b);
            Console.WriteLine(a + "  " + b);

            // You can also omit the type argument and the compiler will infer it. The Following call to Swap is equivalent to 
            //the previous call
            double d1 = 0.1, d2 = 0.2;
            Swap(ref d1, ref d2);
            Console.WriteLine(d1 + "  " + d2);
        }
    }

}