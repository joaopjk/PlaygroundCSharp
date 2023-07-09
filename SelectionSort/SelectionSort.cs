using SwapLib;

namespace SelectionSortAlgorithm
{
    /*
     - In-place algorithm: uses a small amout of extra memory(doesn't depend on n)
     - Unstable
     - O(n2) time complexity (quadratic)
     - Degrades quickly(though usually faster than Bubble Sort)
     */
    public class SelectionSort
    {
        public static void Sorting(int[] array)
        {
            for (int partiIndex = array.Length - 1; partiIndex > 0; partiIndex--)
            {
                int largestAt = 0;
                for (int i = 1; i <= partiIndex; i++)
                {
                    if (array[i] > array[largestAt])
                    {
                        largestAt = i;
                    }
                }
                SwapClass.Swap(array, largestAt, partiIndex);
            }
        }
    }
}