namespace InsertionSortAlgorithm
{
    /*
     - In-place algorithm: use a small of extra memory(doesn't depend on n)
     - Stable
     - O(n2) time complexity(quadratic)
     - Degrades quickly
   */

    public class InsertionSort
    {
        public static void Sorting(int[] array)
        {
            for (int partIndex = 1; partIndex < array.Length; partIndex++)
            {
                int currentUnsorted = array[partIndex];
                int i;
                for (i = partIndex; i > 0 && array[i - 1] > currentUnsorted; i--)
                {
                    array[i] = array[i - 1];
                }
                array[i] = currentUnsorted;
            }
        }
    }
}