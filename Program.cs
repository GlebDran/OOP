using System;
using System.Collections.Generic;
using System.IO;
using OOP;

namespace OOP
{
    class Program
    {
        static List<Kangelane> kangelased = new List<Kangelane>();

        public static void LoeKangelasedFailist(string failinimi)
        {
            if (!File.Exists(failinimi))
            {
                Console.WriteLine("Faili ei leitud: " + failinimi);
                return;
            }

            string[] read = File.ReadAllLines(failinimi);

            foreach (string rida in read)
            {
                string[] osad = rida.Split('/');
                if (osad.Length != 2)
                    continue;

                string nimiRaw = osad[0].Trim();
                string asukoht = osad[1].Trim();

                bool onSuper = nimiRaw.Contains("*");
                string nimi = nimiRaw.Replace("*", "").Trim();

                if (onSuper)
                    kangelased.Add(new SuperKangelane(nimi, asukoht));
                else
                    kangelased.Add(new Kangelane(nimi, asukoht));
            }
        }

        static void Main(string[] args)
        {
            // Загрузка героев из файла
            LoeKangelasedFailist("andmed.txt");

            // Пример вызова методов на обычном и супергерое
            Console.WriteLine("--- Näidiskutsed ---");

            Kangelane tavaline = kangelased.Find(k => k is Kangelane && !(k is SuperKangelane));
            Kangelane super = kangelased.Find(k => k is SuperKangelane);

            if (tavaline != null)
            {
                Console.WriteLine("\nTavaline kangelane:");
                Console.WriteLine(tavaline.ToString());
                Console.WriteLine("Päästetud: " + tavaline.Paasta(1000));
                Console.WriteLine(tavaline.Vormiriietus());
                Console.WriteLine(tavaline.Tervitus());
                Console.WriteLine(tavaline.MissiooniStaatus());
            }

            if (super != null)
            {
                Console.WriteLine("\nSuperkangelane:");
                Console.WriteLine(super.ToString());
                Console.WriteLine("Päästetud: " + super.Paasta(1000));
                Console.WriteLine(super.Vormiriietus());
                Console.WriteLine(super.Tervitus());
                Console.WriteLine(super.MissiooniStaatus());
            }

            // Подсчёт общего количества спасённых
            int koguPaastetud = 0;
            foreach (var kangelane in kangelased)
            {
                koguPaastetud += kangelane.Paasta(1000);
            }
            Console.WriteLine($"\nKangelased päästsid kokku {koguPaastetud} inimest.");
        }
    }
}
