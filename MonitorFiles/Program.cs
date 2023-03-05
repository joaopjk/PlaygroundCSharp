using System;
using System.IO;

namespace MonitorFiles
{
    internal class Program
    {
        static void Main(string[] _)
        {
            FileSystemWatcher watcher = new FileSystemWatcher(@"C:\PastaMonitorada");
            watcher.NotifyFilter = NotifyFilters.FileName |
                                   NotifyFilters.DirectoryName |
                                   NotifyFilters.Attributes |
                                   NotifyFilters.Size |
                                   NotifyFilters.LastAccess |
                                   NotifyFilters.LastWrite |
                                   NotifyFilters.CreationTime |
                                   NotifyFilters.Security;
            watcher.Filter = "*.txt";
            watcher.IncludeSubdirectories = true;
            watcher.EnableRaisingEvents = true;

            watcher.Changed += Watcher_Changed;
            watcher.Created += Watcher_Created;
            watcher.Deleted += Watcher_Deleted;
            watcher.Renamed += Watcher_Renamed;
            watcher.Error += Watcher_Error;

            Console.WriteLine("Pressione qualquer tecla para finalizar o monitorador");
            Console.ReadKey();
        }

        private static void Watcher_Error(object sender, ErrorEventArgs e)
        {
            Exception ex = e.GetException();
            if(ex != null)
                Console.WriteLine($"{ex.Message}");
        }

        private static void Watcher_Renamed(object sender, RenamedEventArgs e)
        {
            if (e.ChangeType != WatcherChangeTypes.Renamed) return;

            Console.WriteLine($"O arquivo {e.OldName} foi renomeado para {e.FullPath}");
        }

        private static void Watcher_Deleted(object sender, FileSystemEventArgs e)
        {
            if (e.ChangeType != WatcherChangeTypes.Deleted) return;

            Console.WriteLine($"O arquivo {e.FullPath} foi deletado");
        }

        private static void Watcher_Created(object sender, FileSystemEventArgs e)
        {
            if (e.ChangeType != WatcherChangeTypes.Created) return;

            Console.WriteLine($"O arquivo {e.FullPath} foi criado");
        }

        private static void Watcher_Changed(object sender, FileSystemEventArgs e)
        {
            if (e.ChangeType != WatcherChangeTypes.Changed) return;

            Console.WriteLine($"O arquivo {e.FullPath} foi alterado");
        }
    }
}
