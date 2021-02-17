using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

//Koden är indelad i sektioner för att den ska vara lättare att läsa
//Använd gärna denna funktion



namespace Inlämning3
{
    public partial class Form1 : Form
    {
        /*
         * Designerar användaren som ska hålla all data från formuläret
         */
        user User;
        public Form1()
        {
            InitializeComponent();
            /*
             * Initierar användaren som ska hålla datan från formuläret
             */
            User = new user();
        }

        private void Change
            (
                object sender,
                EventArgs e
            )
        {
            /*
             * Använder Funktionen update som finns i klassen user för att verfiera att personummeret är giltigt
             * såväl som att updatera förnamn och efternamn
             */
            Output.Text = User.update(FirstName.Text, LastName.Text, Personmr.Text);
        }
    }
    /// <summary>
    /// Klassen som kommer att hålla all relevant data för användaren
    /// </summary>
    public class user
    {
        #region Lokala variabler
        /// <summary>
        /// FirstName är sträng variabeln som kommer att hålla användarens förnamn
        /// </summary>
        public string FirstName;
        /// <summary>
        /// LastName är sträng variabeln som kommer att hålla användarens efternamn
        /// </summary>
        public string LastName;
        /// <summary>
        /// Personr är sträng variablen som kommer att hålla användarens personnummer
        /// </summary>
        public string Personr;
        /// <summary>
        /// gender är sträng variablen som kommer at hålla användarens kön
        /// </summary>
        public string gender;
        /// <summary>
        /// Booleanen som kommer att hålla om personnummret är valid enligt båda algoritmerna
        /// </summary>
        public bool validpnmr;
        #endregion
        /// <summary>
        /// Initizierings funktionen sätter alla variabler till deras standard värde
        /// </summary>
        public user()
        {
            //sätter alla sträng variabler till en tom sträng
            FirstName = "";
            LastName = "";
            Personr = "";
            gender = "";
            //Antar att ett tomt personnummer inte är korrekt
            validpnmr = false;
        }
        /// <summary>
        /// Funktionen som kör alla kontroller på personnummret
        /// </summary>
        public void Validate()
        {
            //Kontrollerar om personnumret har rätt längdn och enbart innehåller siffror, detta är viktigt 
            //eftersom att vi ska använda bokstäverna som tal senare i funktionen
            //Detta görs med så kallade regulare expressions
            #region Personnummerskontroll
            if (
                    Personr.Length == "yymmddxxxx"
                    .Length && Regex
                    .IsMatch(Personr, @"^\d+$")
                )
            {
                #region Könskontroll
                //Kollar om näst sista siffran i personnummret är jämn eller ojämn
                //Detta görs för att bestämma könet på användaren
                if (int.Parse(Personr[8]
                    .ToString()) % 2 == 0)
                    gender = "Kvinna";
                else gender = "Man";
                #endregion
                //Designerar en variabel för att hålla summan
                //den används i följande algoritmer
                int sum = 0;
                #region 21-algoritm
                /*
                 * Påbörjar första algoritmen där man tar alla siffror i personnumret multiplicerat med 2 och 1 
                 * i alternerade ordning
                 * går igenom alla tecken i personnumret och om dess index
                 * är jämt så multiplicerar vi med ett annars multiplicerar vi med två
                 */
                for (int i = 0; i < Personr.Length; i++)
                {
                    //kontrollerar om det i är jämn
                    if ((i) % 2 == 0)
                        //okej detta är lite konstig ordning men men
                        /*
                         * Jag har skrivit en funktion som heter to int array som tar in ett heltal och sedan delar upp talen i ental tiotal osv
                         * så jag ger den siffervärdet av tecknet på index i i personnummret multiplicerat med 2
                         * sen lägger jag till både tiotalet och entalet till summan
                         * 
                         * Detta gör jag eftersom att talen kan bli större än 9 vilket enligt algoritmformuleringen är problematiskt
                         */
                        foreach (int j in ToIntArray(int.Parse(Personr[i].ToString()) * 2))
                            sum += j;
                    //Om talet index inte är jämt så blir det betydligt enklare då läggs bara siffervärdet av tecknet på index i till till summan.
                    else sum += int.Parse(Personr[i].ToString());
                            
                }
                //Om inte är jämt delbar med 10 är det inte lönt att fortsätta med nästa algoritm så då säger vi bara att personnummret inte är validt
                //och avbryter funktionen med ett return statement
                if (sum % 10 != 0)
                {
                    validpnmr = false;
                    return;
                }
                #endregion
                //Nollställer summan
                sum = 0;
                #region Kontrollsiffran
                /*
                 * Påbörjar nästa algorimt
                 * 
                 * Denna ska gå igenom personnumret på samma vis som förra algoritmen men sluta innan sista siffran
                 * så entals siffran i summan dras ifrån 10 om resultatet av det är sista siffran i personnumret så 
                 * är personnumret validt men det finns ett undantag då personnummret slutar på 0 då måste summan också sluta på 0
                 * Min förklaring av loopen kommer jag skippa den finns några rader upp
                 */
                for (int i = 0; i < Personr.Length - 1; i++)
                {
                    if ((i) % 2 == 0) foreach (int j in ToIntArray(
                        (int.Parse(Personr[i]
                        .ToString()) * 2))) sum += j;
                    else sum += int.Parse(Personr[i].ToString());
                }
                //Kontrolerar de kraven jag nämnde i början av algoritmen med hjälp av min funktion ToIntArray
                //eftersom att jag använder samma värde mer än en gång sätter jag nya variabler så att jag slipper
                //göra samma beräkning igen
                string LastChar = Personr[Personr.Length - 1].ToString();
                int LastDigit = ToIntArray(sum)[1];
                //Om kontrollen stämmer så vet vi att båda algoritmerna ger positivt utslag och returnerar därför ett positivit värde
                if (10-LastDigit==int.Parse(LastChar)|| (LastDigit == 0 && LastChar=="0"))
                {
                    validpnmr = true;
                    return;
                }
                //Annars returnerar vi ett negativt värde
                else
                {
                    validpnmr = false;
                    return;
                }
                #endregion

            }
            else
            {
                //Om personnummret inte har rätt längd eller innehåller tecken som inte är siffror returneras ett negativt värde
                validpnmr = false;
            }
            #endregion
        }
        
        /// <summary>
        /// Funktionen som uppdaterar user objektet
        /// den används i detta fallet för att uppdatera output boxen vid någon form av ändring i formuläret
        /// </summary>
        /// <param name="firstname">Förnamnet på användaren</param>
        /// <param name="lastname">Efternamnet på användaren</param>
        /// <param name="personr">Personnummret på användaren</param>
        /// <returns></returns>
        public string update
            (
                string firstname,
                string lastname,
                string personr
            )
        {
            //Updaterar värdena
            FirstName = firstname;
            LastName = lastname;
            Personr = personr;
            //returnerar tostring metoden där alla kontroller körs
            //tyckte att det var rätt snyggt att separera koden så här
            return ToString();
        }
        /// <summary>
        /// Funktionen som separerar ett givet heltal i heltal tiotal osv
        /// den returnerar en ordnad lista med tal i fallande ordning
        /// </summary>
        /// <param name="i"> talet man vill konvertera till en lista </param>
        /// <returns></returns>
        static List<int> ToIntArray(int i)
        {
            //Konverterar talet till en sträng, det är lättare så eftersom att en sträng redan är en lista
            string s = i.ToString();
            //Skapar listan som ska returneras
            List<int> temp = new List<int>();
            //Går igenom listan med bokstäver och lägger till siffervärdet i listan "temp"
            foreach (char c in s) temp.Add(int.Parse(c.ToString()));
            //returnerar listan
            return temp;
        }
        // Ersätter den vanliga to string metoden så att jag kan använda kan kalla på en funktion varje gång för att printa informationen i klassen
        public override string ToString()
        {
            //när jag printar datan vill jag alltid kolla om personnummret stämmer därför kör jag validate funktionen först
            Validate();
            // om personnummret är rätt så printar jag namn personnummer och kön
            #region Validt personnummer
            if (validpnmr)
                return string.Format
                    (
                        "Förnamn : {0}{1}" +
                        " Efternamn : {2}{1}" +
                        " Person nummret är validt {1}" + 
                        "Personnummer : {3}{1}" +
                        "Kön : {4}{1}",
                        FirstName,
                        Environment.NewLine,
                        LastName,
                        Personr,
                        gender
                    );
            #endregion
            //annars printar jag bara namn och några felmedelanden
            #region Invalidt personnumer
            else return
                    string.Format
                    (
                        "Förnamn : {0}{1}" +
                        " Efternamn : {2}{1}" +
                        "Personnummret är av fel format {1}" +
                        "Formatet ska vara yymmddxxxx{1}" +
                        "Enbart siffror är tillåtna som personnummer",
                        FirstName,
                        Environment.NewLine,
                        LastName
                    ) ;
            #endregion

        }
    }
}
