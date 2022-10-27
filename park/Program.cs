using System;
using System.IO;
using System.Collections.Generic;

namespace park
{
    class Program
    {
        static void Main(string[] args)
        {
            feladat f = new feladat();    
        }
    }
    class feladat
    {
        List<adatok> viragok = new List<adatok>();
        public feladat()
        {
            f1();
            f2();
            f3();
            f4();
        }

        void f1()
        {
            string[] sorok = File.ReadAllLines("felajanlas.txt");
            for (int i = 1; i < sorok.Length; i++)
            {
                viragok.Add(new adatok(sorok[i]));
            }
        }

        void f2()
        {
            Console.WriteLine("2.feladat: \nA felajánlások száma: {0}:",viragok.Count);
        }
        void f3()
        {
            Console.WriteLine("3.feladat");
            Console.Write("A bejárat mindkét oldalán ültetők:");
            for (int i = 0; i < viragok.Count; i++)
            {
                if(viragok[i].kapu())
                {
                    Console.Write(" {0}",i+1);
                }
            }


            Console.WriteLine();
        }

        void f4()
        {

            Console.WriteLine("4.feladat");
            Console.WriteLine("Adja meg az ágyás sorszámát!");
            int szam = Convert.ToInt32(Console.ReadLine());

            int db = 0;
            for (int i = 0; i < viragok.Count; i++)
            {
                if (viragok[i].bennVanE(szam))
                {
                    db++;
                }
            }
            Console.WriteLine("A felajánlók száma:{0}",db);

            string szin = "";
            for (int i = 0; i < viragok.Count; i++)
            {
                if (viragok[i].bennVanE(szam))
                {
                    szin = viragok[i].szin;
                    break;
                }
            }
            if (szin!="")
            {
                Console.WriteLine("A virágágyás színe, ha csak az első ültet",szin);
            }
            else
            {
                Console.WriteLine("Ezt az ágyást nem ültetik be");
            }

            string szinek = "";
            for (int i = 0; i < viragok.Count; i++)
            {
                if (viragok[i].bennVanE(szam))
                {
                    szinek += " " + viragok[i].szin;
                }
               
            }
          

        }
    }

    class adatok
    {
        public int kezdo, veg;
        public string szin;

        public adatok(string sor)
        {
            string[] vag = sor.Split(' ');
            kezdo = Convert.ToInt32(vag[0]);
            veg = Convert.ToInt32(vag[1]);
            szin = vag[2];
        }

        public bool kapu()
        {
            return kezdo > veg;
        }

        public bool bennVanE(int szam)
        {
            if (!kapu())
            {
                return kezdo <= szam && szam <= veg;
            }
            else
            {
                return kezdo <= szam || szam <= veg;
            }

        }
    }
}
