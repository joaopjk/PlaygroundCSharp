namespace RercursionAlgorithm
{
    /*
     - Recursive function is a function which calls itself
     - Base case terminates recursive calls chain
     - Calculating factorial
     */
    public class Recursion
    {
        private static int  RecursiveFactorial(int n)
        {
            if (n == 0) return 1;

            return n * RecursiveFactorial(n - 1);
        }

        private static int IterativeFactorial(int number)
        {
            if (number == 0) return 1;

            int factorial = 1;

            for (int i = 1; i < +number; i++)
            {
                factorial *= i;
            }
            return factorial;
        }
    }
}