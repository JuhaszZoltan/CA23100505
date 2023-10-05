using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CA23100505
{
    class Program
    {
        static void Main()
        {
            var repulok = new List<Repulogep>();
            using var sr = new StreamReader(
                @"..\..\..\src\utasszallitok.txt", 
                Encoding.UTF8);
            string fejlec = sr.ReadLine();
            while (!sr.EndOfStream) repulok.Add(new Repulogep(sr.ReadLine()));

            Console.WriteLine($"4. feladat: Adatsorok száma: {repulok.Count}");

            int f5 = repulok.Count(r => r.Tipus.StartsWith("Boeing"));
            Console.WriteLine($"5. feladat: Boeing típusok száma: {f5}");

            var f6 = repulok.OrderBy(r => r.Utas.Max).Last();
            Console.WriteLine("6. feladat: a legtöbb utast szállító repülőgéptípus");
            Console.WriteLine($"\tTípus: {f6.Tipus}");
            Console.WriteLine($"\tElső felszállás: {f6.Ev}");
            Console.WriteLine($"\tUtasok száma: " +
                $"{(f6.Utas.Min == f6.Utas.Max ? f6.Utas.Max : $"{f6.Utas.Min}-{f6.Utas.Max}")}");
            Console.WriteLine($"\tSzemélyzet: " +
                $"{(f6.Szemelyzet.Min == f6.Szemelyzet.Max ? f6.Szemelyzet.Max : $"{f6.Szemelyzet.Min}-{f6.Szemelyzet.Max}")}");
            Console.WriteLine($"\tUtazósebesség: {f6.UtazoSebesseg}");

            Console.WriteLine("7. feladat:");
            var nincsIlyen = new List<string>(Repulogep.KategoriaNevek);
            foreach (var rep in repulok)
            {
                if (nincsIlyen.Contains(rep.SebessegKategoria))
                    nincsIlyen.Remove(rep.SebessegKategoria);
            }
            if (nincsIlyen.Count == 0)
                Console.WriteLine("\tMinden sebességkategóriából van repülőgéptípus");
            else
            {
                string nilystr = string.Empty;
                nincsIlyen.ForEach(kn => nilystr += $"{kn}, ");
                Console.WriteLine($"\t{nilystr[..^2]}");
            }

            using var sw = new StreamWriter(
                @"..\..\..\src\utasszallitok_new.txt",
                false,
                Encoding.UTF8);
            sw.WriteLine(fejlec);
            foreach (var rep in repulok)
            {
                sw.WriteLine(
                    $"{rep.Tipus};" +
                    $"{rep.Ev};" +
                    $"{rep.Utas.Max};" +
                    $"{rep.Szemelyzet.Max};" +
                    $"{rep.UtazoSebesseg};" +
                    $"{rep.FelszalloTomeg / 1000};" +
                    $"{rep.Fesztav * 3.2808f:0}");
            }
        }
    }
}
