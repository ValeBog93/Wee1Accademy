using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;

namespace EsercizioWeek1Academy
{
  public static class Monitoraggio
    {
        public static void CreazioneNuovoFile(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine($" IL nuovo file è stato creato:{e.Name}");
            Thread.Sleep(1000);
            //Lettura del file
            using(StreamReader reader = File.OpenText(e.FullPath))
            {
                Console.WriteLine($"{e.Name} Spese contenute nel file");
                string linea;
                while ((linea =reader.ReadLine()) != null)
                {
                    Console.WriteLine(linea);
                    string data = reader.ReadLine().Split(';')[0];
                    string categoria = reader.ReadLine().Split(';')[1];
                    string descrizione = reader.ReadLine().Split(';')[2];
                    double importo = Convert.ToDouble(reader.ReadLine().Split(';')[3]);
                    Console.WriteLine($"Data - {data} - Categoria - {categoria} - Descrizione {descrizione} - Importo{importo}");
                }
                Console.WriteLine("File è finito");
                reader.Close();
            }
            
            using (StreamWriter  write = File.CreateText(@"C:\Users\faggi\OneDrive\Desktop\Week1Academy\Spese.txt"))
            {
                write.WriteLine($"Letto il file {e.Name} ({e.ChangeType.ToString()})");
                write.Close();

            }
        }
    }
}
