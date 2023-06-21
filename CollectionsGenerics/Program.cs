using System.Collections;
using System.Linq;

namespace CollectionsGenerics
{
    internal class Program
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
        static void Main(string[] _)
        {
            ArrayList al = new(100) { 1, 2, 3, 4, "3", false, true };
            Console.WriteLine(al.Add(100));
            al.AddRange(new string[] { "1", "2", "3" });
            al.Insert(2, 34);
            al.Remove(1);
            al.RemoveAt(0);
            //al.Sort(); Don't work in array with different data types

            Console.WriteLine(al.Capacity + " " + al.Count);

            al.TrimToSize();
            Console.WriteLine(al.Capacity + " " + al.Count);

            al.ToArray().ToList().ForEach(x => Console.WriteLine(x));
            Console.WriteLine("Second foreach");
            foreach (var x in al) Console.WriteLine(x);

            string[] ar = (string[])al.ToArray();
        }
    }
}