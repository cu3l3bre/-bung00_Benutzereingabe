using System;
using System.Text.RegularExpressions;

namespace UebungBenutzereingabe
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * Übungsvorschlag: Eingabeschnittstelle
             * 
             * Benutzer soll seinen Vor- und Nachnamen sowie sein Geburtsdatum
             * (ggf. auch Größe und Emailadresse) über die Konsole eingeben.
             * 
             * Dabei sollen die eingebenen Daten wie folgt überprüft werden:
             * 
             *  - bei Vor- und Nachname sind nur alphabetische Buchstaben sowie '-' zulässig
             *    und es müssen mindestens fünf Zeichen sein
             *    
             *  - bei Größe ist zu prüfen, ob es sich um ein Zahl handelt
             *  - bei Datum ist zu prüfen, ob es sich um ein Datum handelt 
             *    und es darf kein Datum sein, das in der Zukunft liegt
             *  - bei Email sollt die syntaktische Korrektheit geprüft werden 
             *    (Hinweis: reguläre Ausdrücke und die Klasse 'System.Text.RegularExpressions.RegEx')
             *    
             * Zuletzt sollen die eingeben Daten geeignet ausgegeben werden, wobei zusätzlich noch
             * das Alter (in Jahren) angegeben bzw. berechnet werden soll.
             */

            Console.WriteLine("Uebeung zur Benutzereingabe");
            Console.WriteLine("---------------------------");

            String vorname = "";
            String nachname = "";
            String geburtsdatum = "";
            String email = "";
            Char[] letters;

            DateTime datum;
            Boolean datumOK = false;

            Boolean eingabeOK = false;
            Int32 alter = 0;



            while (!eingabeOK)
            {
                Console.Write("Bitte geben Sie Ihren Vornamen ein [min. 3 Buchst.]: ");
                vorname = Console.ReadLine();

                eingabeOK = (vorname.Length >= 3) && (Regex.IsMatch(vorname, @"^[a-zA-Z- ]+$"));

                
                if (eingabeOK)
                {
                    //Console.WriteLine("Eingabe ist korrekt: {0}", vorname.Length);
                    vorname = vorname.ToLower();
                    letters = vorname.ToCharArray();
                    letters[0] = char.ToUpper(letters[0]);
                    vorname =  new String (letters);
                    //vorname = letters.ToString();
                }
                else
                {
                    Console.WriteLine("Eingabe ist falsch, du Trottel:  {0}", vorname);
                }
                
            }



            eingabeOK = false;

            while (!eingabeOK)
            {
                Console.Write("Bitte geben Sie Ihren Nachnamen ein [min. 3 Buchst.]: ");
                nachname = Console.ReadLine();

                eingabeOK = (nachname.Length >= 3) && (Regex.IsMatch(nachname, @"^[a-zA-Z- ]+$"));
                
                if (eingabeOK)
                {
                    // Console.WriteLine("Eingabe ist korrekt: {0}", nachname.Length);
                    nachname = nachname.ToLower();
                    letters = nachname.ToCharArray();
                    letters[0] = char.ToUpper(letters[0]);
                    nachname = new String(letters);
                }
                else
                {
                    Console.WriteLine("Eingabe ist falsch, du Trottel:  {0}", nachname);
                }
                
            }

            //^([012]\d | 30 | 31)/ (0\d | 10 | 11 | 12)/\d{ 4}$
            // ^(31|30|[012]\d|\d)\.(0\d|1[012]|\d)\.(\d{1,6})$

            eingabeOK = false;
                       
            while (!eingabeOK)
            {
                Console.Write("Bitte geben Sie Ihr Geburtsdatum ein: ");
                geburtsdatum = Console.ReadLine();

                eingabeOK = (Regex.IsMatch(geburtsdatum, @"^(31|30|[012]\d|\d)\.(0\d|1[012]|\d)\.(\d{1,6})$"));
                // eingabeOK = true;

                if(eingabeOK)
                {
                    datumOK = DateTime.TryParse(geburtsdatum, out datum);

                    if(datumOK)
                    {
                        if (datum > DateTime.Today)
                        {
                            Console.WriteLine("Das Datum {0} liegt in der Zukunft du Depp", datum);
                            Console.WriteLine("Heute ist der {0}", DateTime.Today);
                            eingabeOK = false;
                        }
                        else
                        {
                            alter = DateTime.Today.Year - datum.Year; // rechnersich nicht ganz richtig :p
                            eingabeOK = true;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Datum konnte nicht geparst werden !!");
                        eingabeOK = false;
                    }

                }
                else
                {
                    Console.WriteLine("Ups, irgendwas war falsch");
                }
            }



            eingabeOK = false;

            while (!eingabeOK)
            {
                Console.Write("Bitte geben Sie Ihre Email ein: ");
                email = Console.ReadLine();

                eingabeOK = (Regex.IsMatch(email, @"^.+@.+\.[^.]{2,}$"));

                
                if (eingabeOK)
                {
                    //Console.WriteLine("Eingabe ist korrekt: {0}", email);
                    email = email.ToLower();
                }
                else
                {
                    Console.WriteLine("Eingabe ist falsch, du Trottel:  {0}", email);
                }
                
            }


            // Ausgabe der Daten
            Console.WriteLine("");
            Console.WriteLine("Ihr Daten lauten wie folgt:");
            Console.WriteLine("Vorname:\t{0}", vorname);
            Console.WriteLine("Nachname:\t{0}", nachname);
            Console.WriteLine("Geburtsdatum:\t{0}", geburtsdatum);
            Console.WriteLine("Alter:\t\t{0}", alter);
            Console.WriteLine("EMail:\t\t{0}", email);

            Console.ReadKey();
        }
    }
}
