using System;
using System.Text;
using System.Threading;

namespace Ohmscher_Rechner
{
    class Program
    {
        //Die Main Methode!
        static void Main(string[] args)
        {
            double Spannung = 0;
            double Widerstand = 0;
            double Strom = 0;
            bool bfehler = false;
            StringBuilder sbEingabe = new StringBuilder();
            double dErgebnis = 0;


            ConsoleKeyInfo ckiTaste;


            //Die Consolenfarbe wird gesetzt
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
            Ohm.Startloading();
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.Clear();
            do
            {
                Console.CursorVisible = true;
                ckiTaste = Ohm.Menue_anzeigen();
                switch (ckiTaste.KeyChar)
                {
                    case '1':
                        do
                        {

                            do
                            {
                                bfehler = false;
                                Ohm.SpannungBerechnen();
                                //Die Zahl von Getdouble die eingelesen wird zur Variable Widerstand convertiert
                                Widerstand = Ohm.Getdouble();
                                //Wenn Widerstand größer als null ist wird gerechnet sonst wird man zurückgesetzt
                                if (Widerstand <= 0)
                                {
                                    Console.Clear();
                                }

                            }
                            while (Widerstand <= 0);

                            Console.SetCursorPosition(9, 7);
                            Console.Write("Bitte den Stromwert eingeben       ");
                            //Die Zahl von Getdouble die eingelesen wird zur Variable Strom convertiert
                            Strom = Ohm.Getdouble();



                            dErgebnis = Strom * Widerstand;
                            Console.SetCursorPosition(9, 10);
                            Console.Write("Ihr Ergebnis ist: ");
                            Console.WriteLine(Ohm.sEinheiten(dErgebnis) + "Volt");
                            Console.SetCursorPosition(9, 17);
                            Console.WriteLine("Escape zum Startmenü andere zum Wiederholen");
                            Console.CursorVisible = false;
                        }
                        while (Console.ReadKey().Key != ConsoleKey.Escape);
                        break;

                    case '2':


                        do
                        {
                            do
                            {
                                bfehler = false;
                                Ohm.WiderstandBerechnen();
                                //Die Zahl von Getdouble die eingelesen wird zur Variable Spannung convertiert
                                Spannung = Ohm.Getdouble();
                                Console.SetCursorPosition(9, 7);
                                Console.Write("Bitte den Stromwert eingeben     ");
                                //Die Zahl von Getdouble die eingelesen wird zur Variable Strom convertiert
                                Strom = Ohm.Getdouble();
                                //Wenn Spannung Null ist muss Strom auch Null sein Wenn Spannung Spannung größer gleich null ist darf Strom nicht kleiner Null sein
                                if (!(Spannung <= 0 && Strom > 0) || !(Spannung >= 0 && Strom < 0))
                                {
                                    if (Strom == 0)
                                    {
                                        Console.SetCursorPosition(9, 10);
                                        Console.WriteLine("Es fließt kein Strom also ist der Widerstand nich definiert");
                                        Console.SetCursorPosition(9, 17);
                                        Console.WriteLine("Escape zum Startmenü andere zum Wiederholen");
                                        Console.CursorVisible = false;
                                        bfehler = true;
                                    }
                                    else
                                    {
                                        //Das Ergebnis wird ausgerechnet
                                        dErgebnis = Spannung / Strom;
                                        Console.SetCursorPosition(9, 10);
                                        Console.Write("Ihr Ergebnis ist: ");
                                        Console.WriteLine(Ohm.sEinheiten(dErgebnis) + "Ohm");
                                        Console.SetCursorPosition(9, 17);
                                        Console.WriteLine("Escape zum Startmenü andere zum Wiederholen");
                                        Console.CursorVisible = false;
                                        bfehler = true;
                                    }
                                }
                                else
                                {
                                    bfehler = false;
                                }
                            }
                            while (bfehler == false);




                        }

                        while (Console.ReadKey().Key != ConsoleKey.Escape);
                        break;


                    case '3':
                        do
                        {
                            do
                            {
                                bfehler = false;
                                Ohm.StromBerechnen();
                                //Die Zahl von Getdouble die eingelesen wird zur Variable Widerstand convertiert
                                Widerstand = Ohm.Getdouble();
                                if (Widerstand > 0)
                                {
                                    bfehler = true;
                                }
                            }
                            while (bfehler == false);
                            do
                            {
                                bfehler = false;
                                Console.SetCursorPosition(9, 7);
                                Console.Write("Bitte den Spannungswert eingeben   ");
                                //Die Zahl von Getdouble die eingelesen wird zur Variable Spannung convertiert
                                Spannung = Ohm.Getdouble();
                                if (Spannung >= 0)
                                {
                                    bfehler = true;
                                }
                            }
                            while (bfehler == false);





                            //Das Ergebnis wird ausgerechnet
                            dErgebnis = Spannung / Widerstand;
                            Console.SetCursorPosition(9, 10);
                            Console.Write("Ihr Ergebnis ist: ");
                            Console.WriteLine(Ohm.sEinheiten(dErgebnis) + "Ampere");
                            Console.SetCursorPosition(9, 17);
                            Console.WriteLine("Escape zum Startmenü andere zum Wiederholen");
                            Console.CursorVisible = false;
                            bfehler = true;



                        }
                        while (Console.ReadKey().Key != ConsoleKey.Escape);
                        break;

                    default:
                        //Wenn die Eingabe unnütz ist wird es dem User mitgelteilt
                        if (ckiTaste.Key != ConsoleKey.Escape)
                        {
                            //Es dauert 3 sekunden bis der User weitermachen darf
                            int Zeit = 3;
                            Console.Clear();
                            Ohm.NacktMenue(ckiTaste);
                            Console.SetCursorPosition(9, 16);
                            //Dazu wartet die Schleife 3 mal 1000ms
                            Console.Write("-  Ihre Eingabe ist Ergebnislos ");
                            for (int i = 0; i < 4; i++)
                            {
                                //Wie lange der User warten muss wird ihm angezeigt
                                Console.SetCursorPosition(42, 16);
                                Console.Write("{0}s  -", Zeit - i);
                                Thread.Sleep(1000);
                            }
                        }
                        break;
                }

            }

            while (ckiTaste.Key != ConsoleKey.Escape);
            //Wenn das Programm beendet ist wartet es 5 sekunden bis es ausgeht
            Console.Clear();
            Console.CursorVisible = false;
            Console.WriteLine("\n\n\n\t\t\t   Programm von Ege Cabuk");
            Console.WriteLine("\t\t\t   ======================");
            Thread.Sleep(3000);
            
        }
    }
}