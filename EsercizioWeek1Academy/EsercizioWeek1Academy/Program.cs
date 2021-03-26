using System;
using System.IO;

namespace EsercizioWeek1Academy
{
    class Program
    {
        static void Main(string[] args)
        {
            //Creazine del file
            Console.WriteLine("Osservatore dei file");
            FileSystemWatcher fsw = new FileSystemWatcher();
            fsw.Path = @"C:\Users\faggi\OneDrive\Desktop\Week1Academy";
            fsw.Filter = "*.txt";

            fsw.NotifyFilter = NotifyFilters.LastWrite
                | NotifyFilters.LastAccess
                | NotifyFilters.FileName
                | NotifyFilters.DirectoryName;

            fsw.EnableRaisingEvents = true;
            fsw.Created += Monitoraggio.CreazioneNuovoFile;

            
            Console.WriteLine("Digita a per uscire");
            while (Console.Read() != 'a') ;

        }
    }
}
