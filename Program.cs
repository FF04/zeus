using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;
using static System.Console;
namespace zeus
{
    class Program
    {
        public static ConsoleColor normal = ConsoleColor.White;
        public static ConsoleColor blue = ConsoleColor.Blue;
        public static ConsoleColor Eingabe = ConsoleColor.Green;

        public static Point currentCursorPos = new Point(5, 5);

        public static int lagesthight = 37;
        public static int lagestwidth = 87;

        public static int nextCurserStop = 0;

        public static List<Point> curserStops = new List<Point>();

        public static void Init()
        {
            Console.TreatControlCAsInput = true;
            Console.Title = "zeus - wc3270";

            Console.OutputEncoding = Encoding.Unicode;//damit er bestimmte zeichen darstellen kann

            SetWindowSize(lagestwidth, lagesthight);
            SetBufferSize(lagestwidth, lagesthight);
            Console.CursorSize = 100;

        }
        static void Main(string[] args)
        {
            System.ConsoleKeyInfo zwischenspeicher;
            string Input = "";


            Init();


            FirstPage();
            //   if (Console.ReadKey(true).Key == ConsoleKey.Enter)

            while (true)
            {
                CheckCurser();

                ForegroundColor = Eingabe;
                Input += Console.ReadKey().KeyChar;
                if (CursorLeft <= 5)//indem man enter drückt ist man in der nächsten zeile am anfang, das wird detected
                    break;

            }
            Console.Clear();

            Input = Input.Remove(Input.Length - 1, 1);//damit das enter weggeht


            if (Input.ToUpper() != "DIAL ZOS22A")
                FirstPageError(Input);



            LoginPanel();


            Input = "";
            nextCurserStop = 1;
            while (true)
            {
                CheckCurser();

                Input += Console.ReadKey(true).KeyChar;
                if (Input == "\t")
                {

                    SetCursorPosition(curserStops[nextCurserStop].X, curserStops[nextCurserStop].Y);

                    nextCurserStop++;
                    if (nextCurserStop >= curserStops.Count) // >= da der index mit 0 beginnt
                    {
                        nextCurserStop = 0;
                    }

                    Input = "";

                }
                else
                {
                    if (Input=="\n")
                    {
#warning staied here
                     
                        break;
                    }
                    if ((CursorTop == 32|| CursorTop == 31))
                    {
                      
                        Console.Write(" ");
                    }
                    else if (Input=="\b")
                    {
                        if (CursorLeft > 55)
                        {


                            Console.ForegroundColor = blue;
                            SetCursorPosition(currentCursorPos.X-1, currentCursorPos.Y);
                            Console.Write("_");
                            SetCursorPosition(currentCursorPos.X - 1, currentCursorPos.Y);

                            Console.ForegroundColor = ConsoleColor.Gray;
                        }
                    }
                    else
                        Console.Write(Input);
                    Input = "";
                }



            }

            curserStops.Clear();
            Clear();














            Console.ReadLine();
        }


        public static void CheckCurser()
        {
            if (CursorLeft != currentCursorPos.X || CursorTop != currentCursorPos.Y)
            {
                //   Unten wird nun die curser pos zahl geändert


                currentCursorPos = new Point(CursorLeft, CursorTop);


                SetCursorPosition(lagestwidth - 8, lagesthight - 1);
                Console.BackgroundColor = ConsoleColor.Black;
                ForegroundColor = ConsoleColor.Gray;
                Console.Write($"0{currentCursorPos.Y}/0{currentCursorPos.X}");
                SetCursorPosition(currentCursorPos.X, currentCursorPos.Y);
            }



        }

        public static void FileOptionsKeyPad()
        {
            SetCursorPosition(0, 0);
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("File     Options     Keypad                                                           ");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = normal;


        }


        public static void FirstPage()
        {


            FileOptionsKeyPad();

            //das tastenkombinationan aktiv sind


            Console.WriteLine();
            Console.WriteLine(" z/VM ONLINE ");
            Console.WriteLine("\n\n\n\n\n\n\n");
            Console.WriteLine("         This is Zeus, the mainframe of the");
            Console.WriteLine("         IBM Z University Program for Europe");
            Console.WriteLine();
            Console.ForegroundColor = blue;
            Console.WriteLine(@"                      _______   _______             _______");
            Console.Write(@"                     / ___   ) (  ____ \ |\     /| (  ____ \"); Console.ForegroundColor = normal; Console.Write("  z/OS\n  Z"); Console.ForegroundColor = blue;
            Console.WriteLine(@"                  \/   )  | | (    \/ | )   ( | | (    \/"); Console.ForegroundColor = normal; Console.Write("   Europe"); Console.ForegroundColor = blue;
            Console.Write(@"                /   ) | (__     | |   | | | (_____ "); Console.ForegroundColor = normal; Console.Write("  z/VM\n    University"); Console.ForegroundColor = blue;
            Console.WriteLine(@"          /   /  |  __)    | |   | | (_____  )"); Console.ForegroundColor = normal; Console.Write("     System"); Console.ForegroundColor = blue;
            Console.Write(@"            /   /   | (       | |   | |       ) |"); Console.ForegroundColor = normal; Console.WriteLine("  Linux for IBM Z"); Console.ForegroundColor = blue;
            Console.WriteLine(@"                      /   (_/\ | (____/\ | (___) | /\____) |");
            Console.Write(@"                     (_______/ (_______/ (_______) \_______)"); Console.ForegroundColor = normal; Console.WriteLine("  z/VSE");
            Console.WriteLine(@"");
            Console.WriteLine(@"  Access only permitted when authorized by explicit agreement with IBM");
            Console.WriteLine("\n\n\n\n");



            ForegroundColor = blue;
            Console.Write(" To access Zeusplex, the Zeus z / OS 2.2 Parallel Sysplex, type "); ForegroundColor = normal; Console.WriteLine("DIAL ZEUSPLEX"); ForegroundColor = blue;
            Console.Write(" or to select an individual member, type DIAL "); ForegroundColor = normal; Console.Write("ZOS22A"); ForegroundColor = blue; Console.Write(" or "); ForegroundColor = normal; Console.WriteLine("DIAL ZOS22B0"); ForegroundColor = blue;
            Console.WriteLine(" To access your own university's second-level z/VM system,   ");
            Console.Write(" type DIAL followed by its name, for example: "); ForegroundColor = normal; Console.WriteLine("DIAL FOOVM");
            Console.WriteLine("");
            Console.WriteLine(" System ===>"); ForegroundColor = blue;
            Console.WriteLine("                                                                RUNNING   ZEUSZVM");
            Console.BackgroundColor = ConsoleColor.Gray; Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("4A ");
            Console.BackgroundColor = ConsoleColor.Black; Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("                                                       S                    ");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("0" + Console.CursorTop + "/0" + Console.CursorLeft);
            Console.SetCursorPosition(12, lagesthight - 3);







        }

        public static void FirstPageError(string txt)
        {
            FileOptionsKeyPad();

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = blue;
            Console.WriteLine(txt);
            Console.WriteLine("HCPCFC015E Command not valid before LOGON:" + txt.ToUpper());
            Console.WriteLine("");
            Console.WriteLine("Enter one of the following commands:");
            Console.WriteLine();
            Console.WriteLine("   LOGON userid                 (Example:  LOGON VMUSER1)  ");
            Console.WriteLine("   DIAL userid                  (Example:  DIAL VMUSER2)         ");
            Console.WriteLine("   MSG userid message           (Example: MSG VMUSER2 GOOD MORNING)");
            Console.WriteLine("   LOGOFF");
            Console.WriteLine("");





            SetCursorPosition(lagestwidth - 20, lagesthight - 2);
            Console.WriteLine("CP READ   ZEUSZVM");
            Console.BackgroundColor = ConsoleColor.Gray; Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("4A ");
            Console.BackgroundColor = ConsoleColor.Black; Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("                                                       S                    ");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("0" + Console.CursorTop + "/0" + Console.CursorLeft);
            Console.SetCursorPosition(0, lagesthight - 3);
            CheckCurser();



            Console.ReadLine();
            Console.Clear();


        }


        public static void LoginPanel()
        {
            FileOptionsKeyPad();
            Console.WriteLine();

            ForegroundColor = Eingabe;
            Console.Write(" Session Manager                     ");
            ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Signon PANEL ");
            ForegroundColor = Eingabe;
            SetCursorPosition(lagestwidth - 19, 2);
            Console.Write($"{DateTime.Now.ToString("yyyy/MM/dd")} {DateTime.Now.ToString("HH:mm:ss")}");
            ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(" LU LA705");
            ForegroundColor = blue;

            WriteLine(@"    _______   _______             _______                    _______   _______   ");
            WriteLine(@"   / ___   ) (  ____ \ |\     /| (  ____ \                //(  ___  ) (  ____ \  ");
            WriteLine(@"   \/   )  | | (    \/ | )   ( | | (    \/               (( | (   ) | | (    \/  ");
            WriteLine(@"       /   ) | (__     | |   | | | (_____       _____    // | |   | | | (_____   ");
            WriteLine(@"      /   /  |  __)    | |   | | (_____  )     (__   )  ((  | |   | | (_____  )  ");
            WriteLine(@"     /   /   | (       | |   | |       ) |       /  /   //  | |   | |       ) |  ");
            WriteLine(@"    /   (_/\ | (____/\ | (___) | /\____) |      /  (__ ((   | (___) | /\____) |  ");
            WriteLine(@"   (_______/ (_______/ (_______) \_______)     (______)//   (_______) \_______)  ");
            WriteLine(@"                                                                                 "); ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("  Access only permitted when authorized by explicit agreement with IBM ");
            Console.WriteLine(); ForegroundColor = blue;
            Console.Write("  This Zeus system is member "); ForegroundColor = ConsoleColor.Cyan; Console.Write("ZOS22A      "); ; ForegroundColor = blue; Console.WriteLine("of sysplex ZEUSPLEX running z/OS 2.2 ");
            Console.Write("  Session manager version is  "); ForegroundColor = ConsoleColor.Cyan; Console.WriteLine("5655-U98 IBM Session Manager for z/OS 3.200B  "); ; ForegroundColor = blue;
            Console.WriteLine("  ---------------------------------------------------------------------------------");
            Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n");
            ForegroundColor = Eingabe;
            Console.Write("                   Enter:      Userid             "); ForegroundColor = ConsoleColor.DarkYellow; Console.Write("===> "); ForegroundColor = blue; curserStops.Add(new Point(Console.CursorLeft, Console.CursorTop)); Console.WriteLine("_________");
            ForegroundColor = Eingabe;
            Console.Write("                               Password           "); ForegroundColor = ConsoleColor.DarkYellow; Console.Write("===> "); curserStops.Add(new Point(Console.CursorLeft, Console.CursorTop)); Console.WriteLine();
            ForegroundColor = Eingabe;
            Console.Write("                               New Password       "); ForegroundColor = ConsoleColor.DarkYellow; Console.Write("===> "); curserStops.Add(new Point(Console.CursorLeft, Console.CursorTop)); Console.WriteLine();
            Console.WriteLine();
            Console.Write(" ===> "); curserStops.Add(new Point(Console.CursorLeft, Console.CursorTop));
            ForegroundColor = ConsoleColor.Cyan;
            while (CursorLeft + 1 < lagestwidth)
            {
                Console.Write("_");
            }
            Console.WriteLine();
            ForegroundColor = Eingabe;
            Console.WriteLine(" PF1:Help  PF2:Transfer  PF3:Logoff  PF7:Bwd   PF8:Fwd   PF9:Transfer Override");



            Console.BackgroundColor = ConsoleColor.Gray; Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("4A ");
            Console.BackgroundColor = ConsoleColor.Black; Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("                                                       S                    ");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("0" + Console.CursorTop + "/0" + Console.CursorLeft);
            Console.SetCursorPosition(lagestwidth - 32, lagesthight - 7);

        }


    }
}
