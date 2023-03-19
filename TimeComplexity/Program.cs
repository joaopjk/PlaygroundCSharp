using System.Diagnostics;

namespace TimeComplexity
{
    internal class Program
    {
        public class In
        {
            public static IEnumerable<int> ReadInts(string filePath)
            {
                using TextReader reader = new StreamReader(filePath);
                string lastLine;

                while ((lastLine = reader.ReadLine()) != null)
                {
                    yield return int.Parse(lastLine);
                }
            }
        }
        static void Main(string[] _)
        {
            var texts = new List<string>()
            {
                "1kints.txt",
                "2kints.txt",
                "4kints.txt",
                "8kints.txt",
                "16kints.txt",
            };
            foreach (var text in texts)
            {
                var ints = In.ReadInts(text).ToArray();
                var watch = new Stopwatch();

                watch.Start();
                var triplets = ThreeSum.Count(ints);
                watch.Stop();

                Console.WriteLine(text);
                Console.WriteLine($"Triplets: { triplets}");
                Console.WriteLine($"Elapsed Time: {watch.Elapsed:g}");
                Console.WriteLine("============================");
            }

            Console.ReadKey();
        }
    }
}