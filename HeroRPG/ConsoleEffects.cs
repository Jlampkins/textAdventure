using System;
using System.Linq;

namespace HeroRPG
{
    public class ConsoleEffects
    {

        public static void TypeLine(string line)
        {
            for (int i = 0; i < line.Length; i++)
            {
                Console.Write(line[i]);
                System.Threading.Thread.Sleep(50); // Sleep for 100 milliseconds
            }
        }

        public static void SpeedLine(string line, int speed)
        {
            for (int i = 0; i < line.Length; i++)
            {
                Console.Write(line[i]);
                System.Threading.Thread.Sleep(speed); // Sleep for input milliseconds
            }
        }

        public static void PressEnter()
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey();
            if (keyInfo.Key == ConsoleKey.Enter)
            {
                Console.Clear();
            }
            

        }

        // Generate a random number between two numbers
        
        public static int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }





        public static void ColorTextCyan(string coloredWords)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(coloredWords);
            Console.ResetColor();
        }

        public static void ColorTextRed(string coloredWords)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(coloredWords);
            Console.ResetColor();

        }

        public static void ColorTextGreen(string coloredWords)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(coloredWords);
            Console.ResetColor();

        }

        public static void ColorTextYellow(string coloredWords)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(coloredWords);
            Console.ResetColor();

        }


        public static string FirstCharToUpper(string name)
        {
           string lowerName = name.Substring(0, 1) + name.Substring(1).ToLower();
           string titleName = lowerName.Substring(0, 1).ToUpper() + lowerName.Substring(1);
           return titleName;
        }


        public static void CharacterText()
        {
            int beepgen1, beepgen2, beepgen3, beepgen4, beepgen5, beepgen6, beepgen7, beepgen8, beepgenn1, beepgenn2, beepgenn3, beepgenn4, beepgenn5, beepgenn6, beepgenn7, beepgenn8;

            beepgen1 = (RandomNumber(37, 7000));
            beepgen2 = (RandomNumber(37, 6000));
            beepgen3 = (RandomNumber(37, 6000));
            beepgen4 = (RandomNumber(37, 7000));
            beepgen5 = (RandomNumber(37, 8000));
            beepgen6 = (RandomNumber(37, 7000));
            beepgen7 = (RandomNumber(37, 7000));
            beepgen8 = (RandomNumber(37, 5000));
            beepgenn1 = (RandomNumber(50, 200));
            beepgenn2 = (RandomNumber(50, 250));
            beepgenn3 = (RandomNumber(50, 300));
            beepgenn4 = (RandomNumber(50, 200));
            beepgenn5 = (RandomNumber(50, 250));
            beepgenn6 = (RandomNumber(50, 200));
            beepgenn7 = (RandomNumber(50, 300));
            beepgenn8 = (RandomNumber(50, 250));

            Console.Beep(beepgen1, beepgenn1);
            Console.Beep(beepgen2, beepgenn2);
            Console.Beep(beepgen3, beepgenn3);
            Console.Beep(beepgen4, beepgenn4);
            Console.Beep(beepgen5, beepgenn5);
            Console.Beep(beepgen6, beepgenn6);
            Console.Beep(beepgen7, beepgenn7);
            Console.Beep(beepgen8, beepgenn8);

        }




    }
}

