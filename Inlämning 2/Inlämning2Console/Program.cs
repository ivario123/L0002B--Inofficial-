using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;

namespace Inlämning2Console
{
    class Program
    {
        //Huvudfunktionen, den används rekursivt för att slippa starta om programmet varje gång
        static void Main(string[] args)
        {
            //Skapar en lista med försäljare 
            List<Seller> sellers = new List<Seller>();
            //Frågar användaren hur många säljare det finns och sparar svaret som n
            //Använder min egen funktion read int, la till den för att jag utför samma operation flera gånger
            long n = ReadInt("Hur många säljare finns det?");
            //Om man har angett ett antal säljare så fortsätter den
            if (n > 0)
            {
                //skapar en ny säljare med hjälp av min ping funktion
                for (long i = 0; i < n; i++)
                {
                    sellers.Add(ping());
                }
                //Grupperar och skriver all intresant data för försäljarna
                group(sellers);
            }
            //Kallar på sig själv så att vi får en loop
            Main(args);

        }
        /// <summary>
        /// Sorterar säljarna och sätter dem sedan i grupper.
        /// </summary>
        /// <param name="sellers">Listan med försäljare</param>
        static void group(List<Seller> sellers)
        {
            //Write to file  är sammanställningen av allt viktigt som skriv till konsollen
            //Det är den datan som ska skrivas till filen
            string WriteToFile = "";
            //Sorterar försäljarna med boublesort metoden
            sellers = boublesort(sellers);
            //Avnänder min lite mer abstrakta print metod
            //Skrev en metod bara för att göra koden mer läsbar
            Print("Gupperar alla : ");
            Print("");
            //Skapar alla grupper man kan vara i, de sparas som en Dictionary 
            Dictionary<List<int>, string> ranges = new Dictionary<List<int>, string>();
            ranges.Add(new List<int>(){ 0,49},"mindre än 50 artiklar");
            ranges.Add(new List<int>() { 50, 99 }, "50-99 artiklar");
            ranges.Add(new List<int>() { 100, 199 }, "100-199 artiklar");
            //Eftersom att det skulle vara mer än 199 sätter jag maxgräns på in.MaxValue
            ranges.Add(new List<int>() { 199, int.MaxValue }, "över 199 artiklar");
            //Plockar ut alla gruppers siffervärden
            var keys = ranges.Keys;
            //Senaste summan är summan av säljare i förra gruppen
            int LatestSum = 0;
            //Senaste index är indexet för senaste gruppen i listan keys
            int LatestIndex = 0; 
            //Loopar igenom alla säljare
            foreach (Seller s in sellers)
            {
                //för varje säljare vill vi se om den passar in i någon grupp
                //så vi loopar igenom alla grupper
                for (int i = 0; i < keys.Count; i++)
                {
                    //listan l är området som gruppen är giltig för
                    List<int> l = keys.ElementAt(i);
                    //Om säljaren passan in i gruppen
                    if (s.antal >= l[0] && s.antal <= l[1])
                    {
                        //Kontrollerar om gruppen är en annan grupp än den förra
                        if (i != LatestIndex)
                        {
                            //Om det fanns någon säljare i förra gruppen
                            if (LatestSum > 0) {
                                //skriv ut hur många säljare som fanns i förra gruppen och spara också raden till WriteToFile
                                WriteToFile += Print(
                                    string.Format(
                                        "{0} säljare ligger på nivå {1} : {2}\n",
                                        LatestSum,
                                        LatestIndex + 1,
                                        ranges[keys.ElementAt(LatestIndex)]
                                        )
                                    );
                                //Skriver en blank rad
                                Print(" ");
                                //Senaste index sätts till den nya gruppen
                                LatestIndex = i;
                                //återställer summan
                                LatestSum = 0;
                            }
                            else
                            {
                                //Om det inte fanns någon i förra gruppen kan vi skippa att skriva ut infon om senaste gruppen
                                LatestIndex = i;
                                LatestSum = 0;
                            }
                        }
                        //För varje användare lägger vi till ett till Senaste summan
                        LatestSum += 1;
                        //Sparar och skriver ut informationen om säljaren
                        WriteToFile += Print(s.ToString());
                        //Skriver en blank rad
                        Print("");
                        
                    }
                }
            }
            //Efter att loopen slutat skrivs och sparas informationen om den sista klassen
            WriteToFile += Print(string.Format("{0} säljare ligger på nivå {1} : {2}\n",
                                    LatestSum,
                                    LatestIndex + 1,
                                    ranges[keys.ElementAt(LatestIndex)]));
            //Skriver en blank rad
            Print("");
            //Skriver all data till cd vilket om man debugar filen Inlämning2Console\bin\Debug\netcoreapp3.1\Output.txt
            // och om man kör det kompilerade programmet Inlämning2Console\bin\Release\netcoreapp3.1\Output.txt
            File.WriteAllText("Output.txt", WriteToFile);

        }
        #region Bekvämlighetsfunktioner
        /// <summary>
        /// ping skapar en ny användare genom att fråga användaren om lite diverse info
        /// </summary>
        /// <returns></returns>
        static Seller ping()
        {
            //Skriver en blank rad
            Print("");
            return
                //Skapar en ny säljare
                new Seller(
                    //Frågar användaren om försäljarens namn
                    Read("Namn : "),
                    //Frågar användaren om försäljarens personnummer
                    ReadInt("Personnummer : "),
                    //frågar användaren om disktrikt
                    Read("Distrikt : "),
                    //Frågar användaren om hur många hur många artiklar försäljaren har sålt
                    ReadInt("Antal sålda artiklar : ")
                );
        }
        /// <summary>
        /// Skriver ett medelande till konsollen och returnerar samma medelande
        /// </summary>
        /// <param name="message">medelandet som skrivs i konsollen</param>
        /// <returns>samma sak som input, jag la till detta för att slippa skapa temporära variabler</returns>
        static string Print(string message)
        {
            //Skriver till konsollen
            Console.WriteLine(message);
            //returnerar samma medelande
            return message;
        }
        /// <summary>
        /// Skriver ett medelande till chatten och väntar sedan på numerisk input
        /// Om inputen inte är numerisk returnerar funktionen sig själv vilket betyder att den
        /// loopar tills användaren anger ett siffervärde
        /// </summary>
        /// <param name="message">medelandet som skrivs i konsollen</param>
        /// <returns>sig själv eller ett användarangivet siffervärde</returns>
        static long ReadInt(string message)
        {
            try
            {
                return long.Parse(Read(message));
            }
            catch
            {
                //om användaren inte anger ett siffervärde så skrivs ett felmedelande och funktionen kallar på sig själv

                Print("Otillåtet uttryck\n får bara innehålla siffror");
                return ReadInt(message);
            }
        }
        /// <summary>
        /// Skriver ett medelande till konsollen och returnerar användarens svar
        /// </summary>
        /// <param name="message">medelandet som skrivs i konsollen</param>
        /// <returns>användarens svar</returns>
        static string Read(string message)
        {
            Print(message);
            return Console.ReadLine();
        }
        #endregion
        /// <summary>
        /// Funktionen som sorterar listan med säljare i stigande ordning 
        /// sorterar efter antalet sålda enheter
        /// </summary>
        /// <param name="sell">Listan med säljare</param>
        /// <returns>En sorterad version av listan </returns>
        static List<Seller> boublesort(List<Seller> sell)
        {
            //Om man inte har bytt ordning på listan sätts swapped till false 
            //och loopen bryts
            bool swapped = false;
            for (int i = 0; i < sell.Count - 1; i++)
            {
                if (sell[i].antal > sell[i+1].antal)
                {
                    swapped = true;
                    Seller temp = sell[i];
                    sell[i] = sell[i + 1];
                    sell[i + 1] = temp;
                }
            }
            if (swapped) return boublesort(sell);
            return sell;
        }
    }
    /// <summary>
    /// Försäljar klassen
    /// </summary>
    class Seller
    {
        /// <summary>
        /// Säljarens namn
        /// </summary>
        public string namn;
        /// <summary>
        /// säljarens personnummer måste vara ett nummer
        /// </summary>
        public long personr;
        /// <summary>
        /// Säljarens distrikt
        /// </summary>
        public string distrikt;
        /// <summary>
        /// Sålda enheter
        /// </summary>
        public long antal;
        /// <summary>
        /// Kontrstruktor funktionen
        /// </summary>
        /// <param name="Namn">Försäljarens namn</param>
        /// <param name="Personr">Försäljarens personnummer</param>
        /// <param name="Distrikt">Försäljarens distrikt</param>
        /// <param name="Antal">Antalet enheter som föräljaren har sålt</param>
        public Seller(string Namn, long Personr,string Distrikt, long Antal)
        {
            namn = Namn;
            personr = Personr;
            distrikt = Distrikt;
            antal = Antal;

        }
        /// <summary>
        /// Enda anledningen till att ha en klass för detta är att slippa formatera outputen för varje induviduelt fall
        /// nu kan jag bara printa Seller.tostring()
        /// </summary>
        /// <returns>En representation av klassen</returns>
        public override string ToString()
        {
            return string.Format("< namn : {0},\t Personnummer : {1},\t distrikt : {2},\t antal : {3} >\n", namn, personr, distrikt, antal);
        }
    }
}
