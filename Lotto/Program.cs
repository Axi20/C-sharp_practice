using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Lotto
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Adatok beolvasása txt-ből
            List<Sorsolas> nyeroszamok = new List<Sorsolas>();
            List<Szamok> szamok = new List<Szamok>();
            string[] sor = File.ReadAllLines("sorsolas.txt");

            foreach (var item in sor)
            {
                string[] ertek = item.Split(';');
                Sorsolas szamObjektum = new Sorsolas(ertek[0], ertek[1], ertek[2], ertek[3], ertek[4], ertek[5]);
                nyeroszamok.Add(szamObjektum);
            }

            // Melyik számból mennyi szerepel a listában

            /* Először létrehozunk egy változót a darabszám elmentéséhez.
            For ciklussal végig megyünk a számokon 1-90-ig.
            A nyeroszamok listán is végig megyünk minden körben, foreach-el
            Ha i egyenlő a nyerőszám listában található számmal, akkor növeljük a db változó értékét*/
            int db = 0;
            for (int i = 1; i < 91; i++)
            {
                foreach (var item in nyeroszamok)
                {
                    //Ternáris operátor - if feltételeket helyettesít - így rövidebbb a kód

                    /* Ha az i értéke megegyezik az adott számmal,
                    akkor 1-et adunk hozzá a db változó értékéhez,
                    ha az i értéke eltér, akkor nem ad hozzá semmit. 
                    Ha a 0-át átírnánk 2-re, akkor hamis feltétel esetén 2 lenne hozzáadva a db-hez. 
                    ? után igaz ág, : után hamis ág. */
                  
                    db += (i == item.firstNumber) ? 1 : 0;
                    db += (i == item.secondNumber) ? 1 : 0;
                    db += (i == item.thirdNumber) ? 1 : 0;
                    db += (i == item.fourthNumber) ? 1 : 0;
                    db += (i == item.fifthNumber) ? 1 : 0;    
                }
                Szamok numbersObject = new Szamok(i, db);
                //Ezért hoztuk létre a 16.sorban a szamok listát.
                //Elmentjük melyik számból hány darab van.
                szamok.Add(numbersObject);
                //Fontos lenullázni a db változó értékét, hogy mindig a nulláról kezdje a számolást.
                db = 0;
            }

            //2. A bekért számnak megfelelő hét nyerőszámai
            Console.Write("Adj meg egy számot 1-90: ");
            string felhasznaloSzama = Console.ReadLine();
            int het = 0;
            //Át kell alakítani a bekért string típusú számot int-re.
            if(int.TryParse(felhasznaloSzama, out het))
            {
                if(het > 0 && het < 53)
                { 
                    foreach (var item in nyeroszamok)
                    {
                        if(item.week == het)
                        {
                            Console.WriteLine($"2. feladat: {item.week}, {item.firstNumber}, {item.secondNumber}, {item.thirdNumber}, {item.fourthNumber}, {item.fifthNumber}");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("A szám nincs a megadott tartományban!");
                }
            }
            else
            {
                Console.WriteLine("Nem megfelelő beviteli érték!");
            }

            //3. Az évben legkevesebbszer kihúzott szám - minimum keresés
            int minDb = int.MaxValue;
            int minSzam = 0;
            foreach (var item in szamok)
            {
                if (minDb > item.darab)
                {
                    minDb = item.darab;
                    minSzam = item.szam;
                }
            }
            Console.WriteLine($"3. feladat: {minSzam} {minDb}");

            //4. Hányszor húztak páros számot - megszámlálás
            int parosDb = 0;
            foreach (var item in szamok)
            {
                if ( item.szam % 2 == 0)
                {
                    parosDb += item.darab;
                }
            }
            Console.WriteLine($"4. feladat: {parosDb}");

            //5-6. Hányszor húzták ki az 5 és 46 számot
            int szam5 = 0;
            int szam46 = 0;
            foreach (var item in szamok)
            {
                if(item.szam == 5)
                {
                    szam5 = item.darab;
                }
                if( item.szam == 46)
                {
                    szam46 = item.darab;
                }
            }
            Console.WriteLine($"5-6. feladat \n5: {szam5} 46: {szam46}");

            //7. Számok kiíratása, hányszor húzták ki
            foreach (var item in szamok)
            {
                Console.WriteLine(item.szam + ";" + item.darab);
            }

            Console.ReadKey();
        }
    }
}
