namespace SwapLib
{
    public static class SwapClass
    {
        public static void Swap(int[] array, int i, int j)
        {
            if (i == j) return;

            (array[j], array[i]) = (array[i], array[j]);
        }
    }
}