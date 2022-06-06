using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using static System.Console;

namespace SingleResponsability
{
    internal class Program
    {
        public class Journal
        {
            private readonly List<string> entries = new();
            private static int count = 0;

            public int AddEntry(string text)
            {
                entries.Add($"{++count}: {text}");
                return count; // memento
            }

            public void RemoveEntry(int index)
            {
                entries.RemoveAt(index);
            }

            public override string ToString()
            {
                return string.Join(Environment.NewLine, entries);
            }

            //public void Save(string filename)
            //{
            //    File.WriteAllText(filename, ToString());
            //}
        }

        public class Persistance
        {
            public void SaveToFile(Journal j, string filename,bool overwrite = false)
            {
                if (overwrite || !File.Exists(filename))
                    File.WriteAllText(filename, j.ToString());
            }
        }

        static void Main(string[] _)
        {
            var journal = new Journal();

            journal.AddEntry("A cried today");
            journal.AddEntry("A ate a bug");
            WriteLine(journal.ToString());

            var p = new Persistance();
            var filename = "algum path";
            p.SaveToFile(journal, filename);

            Process.Start(filename);
        }
    }
}
