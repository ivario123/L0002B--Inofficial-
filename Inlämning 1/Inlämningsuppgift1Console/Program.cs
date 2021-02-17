using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;

namespace Inlämningsuppgift1Console
{
    class Program
    {
        
        static void Main(string[] args)
        {
            //Skapar en dictionary som innehåller alla olika sedlar och mynt
            Dictionary<int, string> Values = new Dictionary<int, string>();
            Values.Add(10000, "Tusen lapp");
            Values.Add(500, "Femhundra lapp");
            Values.Add(200, "Tvåhunda lapp");
            Values.Add(100, "Hundra lapp");
            Values.Add(50, "Femtio lapp");
            Values.Add(20, "Tjugo lapp");
            Values.Add(10, "Tio krona");
            Values.Add(5, "Fem krona");
            Values.Add(2, "Två krona");
            Values.Add(1, "En krona");
            //Ber användaren om pris och betalning genom min rekursiva funktion Ping
            int Pris = Ping("Ange pris:");
            int Betalt = Ping("Betalt:");
            //Beräknar skillnaden mellan betalning och pris
            int Delta = Betalt - Pris;
            //Om man har betalat mer än priset
            if (Delta > 0)
            {
                //Plockar ut värdet på alla sedlar och mynt ur Dictionaryn
                var Numbers = Values.Keys;
                //Går igenom alla värden i numbers från störst till minst
                for (int i = 0; i < Numbers.Count; i++)
                {
                    //plockar ut det aktuella numret ur Numbers listan
                    int n = Numbers.ElementAt(i);
                    //Om n är mindre än kvarvarande skillnad
                    if (Delta >= n)
                    {
                        //X är hur många gånger större än n som skillnaden är
                        int X = Delta / n;
                        //Subtraherar så många n som möjligt ifrån Delta
                        Delta -= n * X;
                        //Skriver ut antalet av just den sedeln eller myntet man får tillbaka
                        Ping(string.Format("{0} : {1}", X, Values[n]), 1);
                    }
                }
            }
            //I instruktionen stog det att man inte skulle skriva ut något om man hade betalat exakt rätt
            //Skrev dock dit ett fall ändå eftersom att jag tyckte att det var snyggare
            //Om man har betalat samma mängd pengar som det kostade skriver den ut att man inte får tillbaka några pengar
            else if (Delta == 0) Ping("Du får inte tillbaka någon växel", 1);
            //Om man har betalat mindre än summan så skriver den ut hur mycket man mer man ska betala
            else Ping(string.Format("Du betalade {0} sek för lite", -Delta), 1);
            //kallar på sig själv igen så att man kan göra fler uträkningar utan att starta om programmet
            Main(args);
        }
        
        /// <summary>
        /// Funktion som pingar användaren och inväntar ett svar
        /// Är inte svaret ett heltal aggerar den också rekursiv funktion genom att returna sig själv
        /// Detta pågår ändå tills att användaren har angett ett rimligt svar
        /// </summary>
        /// <param name="Message">Är värdet som printas ut i konsollen</param>
        /// <returns></returns>
        static int Ping(string Message)
        {
            Console.WriteLine(Message);
            try
            {
                return int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Otillåten input");
                return Ping(Message);
            }
        }
        /// <summary>
        /// Overload till ping funktionen för att enbart pinga användaren
        /// </summary>
        /// <param name="Message"> Är värdet som printas ut i konsollen</param>
        /// <param name="WriteOnly">Meningslös används enbart för att overloada</param>
        static void Ping(string Message, Byte WriteOnly)
        {
            Console.WriteLine(Message);
        }


    }
}
