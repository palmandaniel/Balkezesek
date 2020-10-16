using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Balkezesek
{
    class Program
    {
        static List<Jatekos> jatekosok = new List<Jatekos>();
        static List<char> betuk = new List<char>();
        static int evszamInput = 0;
        static void Beolvas()
        {
            StreamReader file = new StreamReader("balkezesek.csv");
            file.ReadLine();
            while (!file.EndOfStream)
            {
                jatekosok.Add(new Jatekos(file.ReadLine()));
            }

            file.Close();
        }

        static void Feladat3()
        {
            Console.WriteLine("3. feladat: {0}",jatekosok.Count);
        }

        static void Feladat4()
        {
            Console.WriteLine("4. feladat");
            for (int i = 0; i < jatekosok.Count; i++)
            {
                if (jatekosok[i].Utolso.Contains("1999-10"))
                {
                    Console.WriteLine($"\t{jatekosok[i].Nev}, {jatekosok[i].Magassag*2.54} cm");
                }
            }
        }

        static void Feladat5()
        {
            Console.WriteLine("5. Feladat");
            bool bekert = false;
            while (bekert==false)
            {
                Console.WriteLine("Kérek egy 1990 és 1999 közti évszámot");
                evszamInput = int.Parse(Console.ReadLine());

                if (evszamInput<=1999 && evszamInput>=1990)
                {
                    bekert = true;
                }

                else
                {
                    Console.WriteLine("Hibás adat! Kérek egy 1990 és 1999 közti évszámot");
                }
            }
            
            
        }

        static void Feladat6()
        {
            double sumSuly = 0;
            int db = 0;
            for (int i = 0; i < jatekosok.Count; i++)
            {
                if (Szabdal(jatekosok[i].Elso) < evszamInput && evszamInput < Szabdal(jatekosok[i].Utolso))
                {
                    db++;
                    sumSuly += jatekosok[i].Suly;
                }
            }

            double atlagSuly =  sumSuly / db;
            Console.WriteLine("6. feladat: {0} font",Math.Round(atlagSuly,2));
        }

        static void Feladat7()
        {
            Console.WriteLine("7. feladat");
            
            var abc = from j in jatekosok orderby j.Nev group j by j.Nev[0] into abcTemp select abcTemp;

            foreach (var abcGroup in abc)
            {
                Console.WriteLine(abcGroup.Key);
                foreach (var item in abcGroup)
                {
                    Console.WriteLine($"\t{item.Nev}");
                }
            }
        }


        public static int Szabdal(string a)
        {
            string[] adat = a.Split('-');
            return int.Parse(adat[0]);
        }

        public static char Vagdos(string a)
        {
            string[] adat = a.Split();
            return char.Parse(adat[0]);
        }

        static void Main(string[] args)
        {
            Beolvas();
            Feladat3();
            Feladat4();
            Feladat5();
            Feladat6();
            Feladat7();

            Console.ReadKey();
        }
    }
}
