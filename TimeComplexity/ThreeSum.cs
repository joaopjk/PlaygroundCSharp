namespace TimeComplexity
{
    internal class ThreeSum
    {
        public static int Count(int[] nums)
        {
            int total = nums.Length;
            int count = 0;

            for (int i = 0; i < total; i++)
            {
                for (int j = i + 1; j < total; j++)
                {
                    for (int k = j + 1; k < total; k++)
                    {
                        if (nums[i] + nums[j] + nums[k] == 0)
                            count++;
                    }
                }
            }

            return count;
        }
    }
}
