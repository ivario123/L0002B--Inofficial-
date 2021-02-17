using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InlämningsUppgift1
{
    public partial class Form1 : Form
    {
        Dictionary<int, string> Values = new Dictionary<int, string>();
        //Initierar formuläret
        public Form1()
        {
            InitializeComponent();
            //Lägger till alla olika sedlar och mynt i ett Dictionary

            Values.Add(10000 , "Tusen lapp");
            Values.Add(500 , "Femhundra lapp");
            Values.Add(200 , "Tvåhunda lapp");
            Values.Add(100 , "Hundra lapp");
            Values.Add(50 , "Femtio lapp" );
            Values.Add(20 , "Tjugo lapp");
            Values.Add(10 , "Tio krona");
            Values.Add(5 , "Fem krona");
            Values.Add(2 , "Två krona");
            Values.Add(1 , "En krona");

        }
        private void ChangeOut(object sender, EventArgs e)
        {
            //Räknar om hur mycket växel man får tillbaka
            Compute();
        }
        /*
         * Funktion som beräknar hur mycket växel man får tillbaka
         * Skrev en funktion för att kunna utvidga koden lättare senare
        */
        private void Compute()
        {
            /*
             * plockar ut nycklarna från Dictionaryn som skapades tidigare i koden
             * Dessa nycklar är värdet på alla olika seldar och mynt
             */
            var Numbers = Values.Keys;
            //Kommer hålla värdet av hur mycket kunden har betalat
            int betalat;
            //Kommer hålla värdet av hur mycket varan kostade
            int pris;
            // try catch gör så att programmet inte craschar när man anger text eller liknande
            // tyckte att det var lite snyggare
            try
            {
                //Omvandlar Betalda summan från text till heltal
                betalat = int.Parse(Betalat.Text);
            }
            catch
            {
                //Om man inte har angett en siffra så sätter den output textrutans text till följande
                Change.Text = "Du måste ange ett siffervärde för hur mycket du har betalt";
                return;
            }
            try
            {
                //Omvandlar Preisets summa från text till heltal
                pris = int.Parse(Pris.Text);
            }
            catch
            {
                //Om man inte har angett en siffra så sätter den output textrutans text till följande
                Change.Text = "Du måste ange ett siffervärde för hur mycket det kostade";
                return;
            }
            //OverPay är hur mycket mer än priset man har betalat
            int OverPay = betalat - pris;
            //print är texten som kommer att sättas i output text rutan i slutet
            string print = string.Format("Du får tillbaka:{0}", Environment.NewLine);
            // I instruktionen stog det att man inte skulle skriva ut något om man hade betalat exakt rätt
            //Skrev dock dit ett fall ändå eftersom att jag tyckte att det var snyggare
            //Om man har betalat exat så mycket man ska så får körs inte alla kontroller
            if (OverPay == 0)
            {
                Change.Text = "Du får ingen växel";
                return;
            }
            //ifall man har betalat mindre än priset kör den inte alla kontroller den retrunerar enbart hur mycket man måste betala
            if (OverPay < 0)
            {
                //Avänder string format för att skriva text med samma utseende på ett enkelt sätt
                Change.Text=string.Format("Du måste betala {0} sek till", -OverPay);
                return;
            }
            //loopar igenom alla värden som finns i Numvers
            for (int i = 0; i < Numbers.Count; i++)
            {
                //designerar en variabel n för att slippa leta i listan mer än en gång
                int n = Numbers.ElementAt(i);
                //Kontrollerar om n är mindre eller lika med resterande summa
                if (OverPay >= n)
                {
                    //Om n är mindre eller lika med resterande summa beräknas hur många gånger större resterande
                    //summa är jämfört med n detta kallar vi x
                    int X = (OverPay / n);
                    //subtraherar bort så många n som vi kan från resterande summan
                    OverPay -= X * n;
                    //lägger till en rad till texten som ska skrivas ut där jag anger hur många av en viss sedel eller mynt man får tillbaka
                    print += "" + string.Format("{0} * {1} {2}", X, Values[n], Environment.NewLine);
                }
            }
            /*
             * avslutar funktionen med att sätta output text rutan "Change" till den till texten som
             * lagras i print
             */
            Change.Text = print;
        }

        private void Pris_Click(object sender, EventArgs e)
        {
            //Tar bort placeholder texten så fort man klickar på pris rutan
            if (Pris.Text == "Vad kostade det?") Pris.Text = "";
        }

        private void Betalat_Click(object sender, EventArgs e)
        {
            //Tar bort placeholder texten så fort man klickar på betalat rutan
            if (Betalat.Text == "Vad betalde du?") Betalat.Text = "";
        }
    }
}
