using System;
using System.Text;
using System.Threading;

namespace Ohmscher_Rechner
{
    public class Ohm
    {
        public static void SpannungBerechnen()
        {
            //Dem User wird angezeigt was er ausrechnet
            Console.Clear();
            Console.CursorVisible = true;
            Console.WriteLine("\n\n\t Hier berechnen Sie die Spannung");
            Console.WriteLine("\t ===============================");
            Console.WriteLine("\n\n\t");
            Console.Write("\n\n\n\n\n\n\t Der Widerstand darf nicht kleiner gleich null sein ");
            Name();
            //Console.SetCursorPosition(Wind)
            Console.SetCursorPosition(9, 5);
            Console.Write("Bitte den Widerstandswert eingeben ");
        }
        public static void WiderstandBerechnen()
        {
            //Dem User wird angezeigt was er ausrechnet
            Console.Clear();
            Console.CursorVisible = true;
            Console.WriteLine("\n\n\t Hier berechnen Sie den Widerstand");
            Console.WriteLine("\t ===============================");
            Console.WriteLine("\n\n\t");
            Console.Write("\n\n\n\n\n\n\n\t Wenn Spannung negativ ist muss Strom auch negativ sein ");
            Console.Write("\n\t Wenn Spannung 0 ist muss Strom auch 0 sein ");
            Name();
            Console.SetCursorPosition(9, 5);
            Console.Write("Bitte den Spannungswert eingeben ");
        }
        public static void StromBerechnen()
        {
            //Dem User wird angezeigt was er ausrechnet
            Console.Clear();
            Console.CursorVisible = true;
            Console.WriteLine("\n\n\t Hier berechnen Sie den Strom");
            Console.WriteLine("\t ===============================");
            Console.WriteLine("\n\n\t");
            Console.Write("\n\n\n\n\n\n\t Der Widerstand darf nicht kleiner gleich null sein ");
            Console.Write("\n\t Die Spannung darf nicht kleiner null sein ");
            Name();
            Console.SetCursorPosition(9, 5);
            Console.Write("Bitte den Widerstandswert eingeben ");

        }
        //Eine Methode für das Menü
        public static ConsoleKeyInfo Menue_anzeigen()
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
            Console.CursorVisible = true;


            ConsoleKeyInfo Auswahltaste;

            Console.WriteLine("\n\n\t Berechnung nach Ohmschen Gesetz");
            Console.WriteLine("\t ==============================");
            Console.WriteLine("\n\n\t Spannung   \t\t <1> ");
            Console.WriteLine("\n\n\t Wiederstand\t\t <2>");
            Console.WriteLine("\n\n\t Strom      \t\t <3>");
            Console.WriteLine("\n\n\n\t -  ESC für Programmabbruch  -");
            Console.WriteLine("\n\n\n\t Ihre Eingabe  \t\t < > ");
            Name();
            Console.SetCursorPosition(34, 20);

            Auswahltaste = Console.ReadKey();

            return Auswahltaste;
        }
        //Eine Methode für das Menü ohne Tasteneinlesung
        public static void NacktMenue(ConsoleKeyInfo ckiTaste)
        {
            Console.WriteLine("\n\n\t Berechnung nach Ohmschen Gesetz");
            Console.WriteLine("\t ==============================");
            Console.WriteLine("\n\n\t Spannung   \t\t <1> ");
            Console.WriteLine("\n\n\t Wiederstand\t\t <2>");
            Console.WriteLine("\n\n\t Strom      \t\t <3>");
            Console.WriteLine("\n\n\n\t -  ESC für Programmabbruch  -");
            Console.WriteLine("\n\n\n\t Ihre Eingabe  \t\t <{0}> ", ckiTaste.KeyChar);
            Name();
            Console.SetCursorPosition(34, 20);
        }
        public static void Name()
        {
            Console.SetCursorPosition(68, Console.WindowHeight - 1);
            Console.Write("~Ege Cabuk~");
        }
        //Eine getDouble Methode um Fehlermeldungen beim Rechnen zu verhindern
        public static double Getdouble()

        {  //das zuletzt eingetippte Zeichen
            ConsoleKeyInfo ckiTaste;
            //Gespeicherte Eingabe
            StringBuilder sbEingabe = new StringBuilder();
            //Die Zahl mit der gerechnet wird
            double dZahl = 0;
            int iBeginn = Console.CursorLeft;
            //Die Stelle wo das E im StringBuilder gesetzt wurde
            int iE = 0;
            //Die Stelle wo das - im StringBuilder gesetzt wurde
            int iMinus = 0;
            //Die Stelle wo das - hinterm E im StringBuilder gesetzt wurde
            int iMinusE = 0;
            //Die Stelle wo das , im StringBuilder gesetzt wurde
            int iKomma = 0;
            //Die Abfrage ob E gesetzt wurde
            bool bE = true;
            //Die Abfrage ob das Minus nach dem E gesetzt wurde
            bool bMinusE = true;
            bool bEnde = true;
            do
            {
                //Speichert einen Tastendruck
                ckiTaste = Console.ReadKey(true);
                //Diese Tasten und Kombinationen werden nicht gestattet
                if (ckiTaste.Modifiers != ConsoleModifiers.Control &&
                    ckiTaste.Modifiers != ConsoleModifiers.Shift &&
                    ckiTaste.Modifiers != ConsoleModifiers.Alt &&
                    ckiTaste.KeyChar != '€' &&
                    ckiTaste.KeyChar != '^' &&
                    ckiTaste.KeyChar != '{' &&
                    ckiTaste.KeyChar != '[' &&
                    ckiTaste.KeyChar != ']' &&
                    ckiTaste.KeyChar != '}' &&
                    ckiTaste.KeyChar != '´' &&
                    ckiTaste.KeyChar != '`')
                {
                    switch (ckiTaste.KeyChar)
                    {

                        case '1':
                        case '2':
                        case '3':
                        case '4':
                        case '5':
                        case '6':
                        case '7':
                        case '8':
                        case '9':
                        case '0':
                            //Wenn der Stringbuilder nicht größer als 50 Zeichen lang ist darf eine Zahl hinzugefügt werden, außer ein E ist im Stringbuilder, dann dürfen 53 Zeichen eingesetzt werden
                            if (sbEingabe.Length < 201 && bE && bMinusE || sbEingabe.Length < 204 && !bE || !bMinusE)
                            {
                                if (bE || iE > sbEingabe.Length - 2)
                                {
                                    //Ergänzt die zuletzt gedrückte Zahl wenn die Anzahl der Zeichen im Exponenten nicht höher als 2 ist
                                    sbEingabe.Append(ckiTaste.KeyChar);
                                    Console.Write(ckiTaste.KeyChar);
                                }
                                else if (bE && bMinusE || iMinusE > sbEingabe.Length - 2)
                                {
                                    //Ergänzt die zuletzt gedrückte Zahl wenn die Anzahl der Zeichen im Exponenten nicht höher als 2 ist
                                    sbEingabe.Append(ckiTaste.KeyChar);
                                    Console.Write(ckiTaste.KeyChar);
                                }
                            }
                            break;

                    }
                    switch (ckiTaste.Key)
                    {
                        case ConsoleKey.Backspace:
                            if (sbEingabe.Length != 0)
                            {
                                //Wenn das letzte Zecihen eine Zahl war passiert nichts
                                if (iE != sbEingabe.Length && iMinus != sbEingabe.Length && iMinusE != sbEingabe.Length)
                                {

                                }
                                //Wenn das letzte Zeichen das "E" war, wird die stelle von "E" zurückgesetzt
                                else if (iE == sbEingabe.Length)
                                {
                                    iE = 0;
                                    bE = true;
                                }
                                //Wenn das letzte Zeichen das "-" war, wird die stelle von "-" zurückgesetzt
                                else if (iMinus == sbEingabe.Length)
                                {
                                    iMinus = 0;
                                }
                                //Wenn das letzte Zeichen das "- hinterm E" war, wird die stelle von "- hinterm E" zurückgesetzt
                                else if (iMinusE == sbEingabe.Length)
                                {
                                    iMinusE = 0;
                                    bMinusE = true;
                                }
                                //Wenn das letzte Zeichen das "," war, wird die stelle von "," zurückgesetzt
                                else if (iKomma == sbEingabe.Length)
                                {
                                    iKomma = 0;
                                }

                                if (Console.CursorLeft != Console.WindowLeft)
                                {
                                    //löscht das letzte Zeichen
                                    sbEingabe.Remove(sbEingabe.Length - 1, 1);
                                    //setzt den Cursor vor das letzte Zeichen
                                    Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                                    //Überschreibt das letzte Zeichen mit einem Leerzeichen
                                    Console.Write(" ");
                                    //setzt den Cursor vor das letzte Zeichen
                                    Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                                }
                                else if (Console.CursorLeft == Console.WindowLeft)
                                {
                                    //löscht das letzte Zeichen
                                    sbEingabe.Remove(sbEingabe.Length - 1, 1);
                                    //setzt den Cursor eine Zeile nach oben
                                    Console.SetCursorPosition(iBeginn + sbEingabe.Length, Console.CursorTop - 1);
                                    //Das Letzte Zeichen wird mit einem Leerzeichen überschrieben
                                    Console.Write(" ");
                                    //setzt den Cursor eine Zeile nach oben
                                    Console.SetCursorPosition(iBeginn + sbEingabe.Length, Console.CursorTop - 1);
                                }
                            }
                            break;

                        case ConsoleKey.OemPeriod:
                        case ConsoleKey.OemComma:
                        case ConsoleKey.Decimal:
                            //Ein Komma kann nur dann gesetzt werden, wenn noch kein Komma im StringBuilder ist, wenn noch kein "e" im Stringbuilder ist und wenn das letzte Zeichen kein Minus ist.
                            if (sbEingabe.ToString().IndexOf(",") < 0 && bE && iMinus != sbEingabe.Length)
                            {
                                sbEingabe.Append(",");
                                Console.Write(",");
                                iKomma = sbEingabe.Length;
                            }
                            break;


                        case ConsoleKey.E:
                            //E kann nur gesetzt werden, wenn kein anderes E im Stringbuilder enthalten ist, der String nicht leer ist, das Letzte Zeichen nicht das Minuszeichen und das Kommazeichen war
                            if (bE &&
                                sbEingabe.Length != 0 &&
                                iMinus != sbEingabe.Length &&
                                iKomma != sbEingabe.Length)
                            {
                                sbEingabe.Append(ckiTaste.KeyChar);
                                Console.Write(ckiTaste.KeyChar);
                                iE = sbEingabe.Length;
                                bE = false;
                            }
                            break;

                        case ConsoleKey.OemMinus:
                        case ConsoleKey.Subtract:
                            //Das Minuszeichen wird nur dann gesetzt, wenn der StringBuilder noch kein anderes Zeichen enthält oder wenn das letzte Zeichen das "e" war
                            if (sbEingabe.Length == 0)
                            {
                                sbEingabe.Append("-");
                                Console.Write("-");
                                iMinus = sbEingabe.Length;
                            }
                            else if (iE == sbEingabe.Length)
                            {
                                sbEingabe.Append("-");
                                Console.Write("-");
                                iMinusE = sbEingabe.Length;
                                bMinusE = false;
                            }
                            else { }
                            break;

                        case ConsoleKey.Enter:
                            //Das Programm wird erst beendet wenn das letzte Zeichen eine Zahl war
                            if (sbEingabe.Length != 0 &&
                                iE != sbEingabe.Length &&
                                iMinus != sbEingabe.Length &&
                                iMinusE != sbEingabe.Length)
                            {
                                bEnde = false;
                            }
                            break;
                    }
                }
            }
            while (bEnde);

            dZahl = Convert.ToDouble(sbEingabe.ToString());
            return dZahl;
        }
        //Eine Methode damit das Ergebnis verkürzt dargestellt wird
        public static string sEinheiten(double dZahl)
        {
            //Ein Array mit den Einheitswerten passend zur potenz
            string[] sP = new string[] { "E", "P", "T", "G", "M", "K", "", "m", "µ", "n", "p", "f", "a" };
            int iExpo = 6;

            while (dZahl > 999 && iExpo > 0)
            {
                dZahl /= 1000;
                iExpo--;
            }
            if (1 > dZahl && dZahl > 0)
            {
                iExpo = 6;
            }
            while (1 > dZahl && dZahl > 0 && iExpo < 13)
            {
                dZahl *= 1000;
                iExpo++;
            }
            dZahl = Math.Round(dZahl, 4);
            return dZahl.ToString() + " " + sP[iExpo];
        }
        //Eine Methode zur Erstellung eines "Loading Screens"
        public static void Startloading()
        {

            do
            {
                Name();
                //Der MausZeiger wird nicht sichtbar.
                Console.CursorVisible = false;
                // Die Hintergrund Farbe der Console wird vertauscht um die Leerzeichen erkennbar zu machen.    
                Console.BackgroundColor = ConsoleColor.White;
                //Eine Do While Schleife die nach der betätigung von der Entertaste und vollendeten for int Schleifen zu Ende geht
                for (int i = 0; i <= 20; i++)
                {
                    //Der Cursor wird auf die MItte der Console gesetzt wobei die Länge des Textes bzw. Der Leerzeichen der hier nach kommenden Do While Schleife berücksichtigt wird.
                    Console.SetCursorPosition((Console.WindowWidth / 2) - ("            ".Length), Console.WindowHeight / 2 - 1);
                    for (int y = 0; y < i; y++)
                    {
                        Console.Write(" ");

                    }
                    //Die Farben werden getauscht um den Lade Vorgang zur Visualisierung zu ermöglichen
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.ForegroundColor = ConsoleColor.White;
                    //Da die Variable i nur bis 20 hochsteigt und ich den Ladevorgang in Prozenten angeben will muss ich i multipliziert mit 5 nehmen, 
                    //weil die 20 in 100 5 mal reinpasst und ich, wenn ich i multipliziert mit 5 nehme am ende auf "100%" komme, sonnst würde ich ohne die Muliplikation von i mit 5 nur auf "20%" kommen.
                    Console.Write(i * 5 + "%");
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Blue;
                    //Die Sleep Methode wird benutzt damit dieser Loading screen nicht direkt auf Hundert springt.
                    Thread.Sleep(100);
                }
                //Der Cursor wird wieder in die Mitte gesetzt.
                Console.SetCursorPosition((Console.WindowWidth / 2) - ("          ".Length), Console.WindowHeight / 2 - 1);
                Console.Write("Enter für Start!");





                //Bei der betätigung der Entertaste wird die Schleife beendet

                while (Console.ReadKey(true).Key != ConsoleKey.Enter)
                {
                }
                return;
            } while (Console.ReadKey(true).Key != ConsoleKey.Enter);





        }
    }
}
