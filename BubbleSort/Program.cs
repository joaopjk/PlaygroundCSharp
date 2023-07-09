namespace BubbleSortAlgorithm
{
    /*
     - In-place algorithm: use a small of extra memory(doesn't depend on n)
     - Stable
     - O(n2) time complexity(quadratic)
     - Degrades quickly
     */

    public static class BubbleSort
    {
        public static void Sorting(int[] array)
        {
            for(int partIndex = array.Length - 1; partIndex > 0; partIndex--)
            {
                for(int i  = 0; i < partIndex; i++)
                {
                    if (array[i] > array[i + 1])
                        Swap(array, i, i + 1);
                }
            }
        }
        private static void Swap(int[] array, int i, int j)
        {
            if (i == j) return;

            (array[j], array[i]) = (array[i], array[j]);
        }
    }
}