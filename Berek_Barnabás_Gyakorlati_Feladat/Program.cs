using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Berek_Barnabás_Gyakorlati_Feladat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Jatek> lista = File.ReadAllLines("Barnabás Berek - games_dataset.csv").Skip(1).Select(sor => new Jatek(sor)).ToList();

            // 1. feladat
            Console.WriteLine("\n1. feladat");
            Console.WriteLine("Magas értékelésű játékok: ");
            lista.Where(x => x.Ertekeles >= 9).ToList().ForEach(x => Console.WriteLine(x.Nev));

            // 2. feladat
            Console.WriteLine("\n2. feladat");
            Console.WriteLine("Több feltételes szűrés: ");
            lista.Where(x => x.Platform == "Nintendo Switch" && x.Kiadas_Ev > 2015 && x.Ertekeles >= 8).ToList().ForEach(x => Console.WriteLine(x.Nev));

            // 3. feladat
            Console.WriteLine("\n3. feladat");
            lista.OrderByDescending(x => x.Kiadas_Ev).ToList().ForEach(x => Console.WriteLine($"{x.Nev} ({x.Kiadas_Ev})"));

            // 4. feladat
            Console.WriteLine("\n4. feladat");
            lista.OrderByDescending(x => x.Ertekeles).Take(10).ToList().ForEach(x => Console.WriteLine($"{x.Nev} - {x.Ertekeles}"));

            // 5. feladat
            Console.WriteLine("\n5. feladat");
            lista.GroupBy(x => x.Platform).ToList().ForEach(x => Console.WriteLine($"{x.Key}: {x.Count()} db"));

            // 6. feladat
            Console.WriteLine("\n6. feladat");
            var legtobbTipus = lista.GroupBy(x => x.Tipus).OrderByDescending(x => x.Count()).First();
            Console.WriteLine($"A legtöbb játék ebből a típusból van: {legtobbTipus?.Key} ({legtobbTipus?.Count()} db)");

            // 7. feladat
            Console.WriteLine("\n7. feladat");
            Console.WriteLine($"Átlagos értékelés: {lista.Average(x => x.Ertekeles):F2}");

            // 8. feladat
            Console.WriteLine("\n8. feladat");
            var legjobbPlatform = lista.GroupBy(x => x.Platform).Select(y => new { Platform = y.Key, Atlag = y.Average(x => x.Ertekeles) }).OrderByDescending(x => x.Atlag).FirstOrDefault();
            Console.WriteLine($"Legmagasabb átlagos értékelésű platform: {legjobbPlatform?.Platform} ({legjobbPlatform?.Atlag:F2})");

            // 9. feladat
            Console.WriteLine("\n9. feladat");
            var legjobbJatek = lista.OrderByDescending(x => x.Ertekeles).FirstOrDefault();
            var legrosszabbJatek = lista.OrderBy(x => x.Ertekeles).FirstOrDefault();
            Console.WriteLine($"Legmagasabb: {legjobbJatek?.Nev} ({legjobbJatek?.Ertekeles}), Legalacsonyabb: {legrosszabbJatek?.Nev} ({legrosszabbJatek?.Ertekeles})");

            // 10. feladat
            Console.WriteLine("\n10. feladat");
            lista.Select(x => x.Tipus).Distinct().ToList().ForEach(x => Console.WriteLine(x));

            // 11. feladat
            Console.WriteLine("\n11. feladat");
            lista.Select(x => new { x.Nev, x.Kiadas_Ev }).ToList().ForEach(x => Console.WriteLine($"{x.Nev} [{x.Kiadas_Ev}]"));

            // 12. feladat
            Console.WriteLine("\n12. feladat");
            lista.Where(x => x.Tipus == "Action").OrderByDescending(x => x.Ertekeles).Select(x => new { x.Nev, x.Kiadas_Ev, x.Ertekeles }).ToList().ForEach(x => Console.WriteLine($"{x.Nev} ({x.Kiadas_Ev}) - Értékelés: {x.Ertekeles}"));

            // 13. feladat
            Console.WriteLine("\n13. feladat");
            lista.GroupBy(x => x.Tipus).ToList().ForEach(x => Console.WriteLine($"{x.Key} átlagos értékelése: {x.Average(y => y.Ertekeles):F2}"));

            // 14. feladat
            Console.WriteLine("\n14. feladat");
            Console.WriteLine("2005 előtt kiadott játékok: ");
            lista.Where(x => x.Kiadas_Ev < 2005).ToList().ForEach(x => Console.WriteLine($"{x.Nev} ({x.Kiadas_Ev})"));

            Console.ReadKey();
        }
    }
}
