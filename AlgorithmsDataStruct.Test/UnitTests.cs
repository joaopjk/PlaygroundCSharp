using BubbleSortAlgorithm;
using NUnit.Framework;
using SelectionSortAlgorithm;

namespace AlgorithmsDataStruct.Test
{
    [TestFixture]
    internal class UnitTests
    {
        private static int[][] Samples()
        {
            int[][] samples = new int[9][];

            samples[0] = new[] { 1 };
            samples[1] = new[] { 2, 1 };
            samples[2] = new[] { 2, 1, 3 };
            samples[3] = new[] { 1, 1, 1 };
            samples[4] = new[] { 2, -1, 3, 3 };
            samples[5] = new[] { 4, -5, 3, 3 };
            samples[6] = new[] { 0, -5, 3, 3 };
            samples[7] = new[] { 0, -5, 3, 0 };
            samples[8] = new[] { 3, 2, 5, 5, 1, 0, 7, 8 };

            return samples;
        }

        private static void RunTestsForSortAlgorithm(Action<int[]> sort)
        {
            foreach (int[] sample in Samples())
            {
                sort(sample);
                CollectionAssert.IsOrdered(sample);
                PrintOut(sample);
            }
        }

        private static void PrintOut(int[] sample)
        {
            TestContext.WriteLine("-------Trace------\n");
            foreach (var item in sample)
            {
                TestContext.Write(item + " ");
            }
            TestContext.WriteLine("------------------\n");
        }

        [Test]
        public void ValidInput_BubbleSort_SortedInput()
        {
            RunTestsForSortAlgorithm(BubbleSort.Sorting);
        }

        [Test]
        public void ValidOutput_SolectionSort_SortedOutput()
        {
            RunTestsForSortAlgorithm(SelectionSort.Sorting);
        }
    }
}
