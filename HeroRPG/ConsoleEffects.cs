using System;
using System.Linq;
using System.Media;
using System.Reflection;
using System.Threading;

namespace HeroRPG
{
    public class ConsoleEffects
    {

        public static void TypeLine(string line)
        {
            SoundPlayer player = new SoundPlayer(Properties.Resources.MainVoice);
            player.PlayLooping();
            for (int i = 0; i < line.Length; i++)
            {
                Console.Write(line[i]);
                System.Threading.Thread.Sleep(75); // Sleep for 100 milliseconds
            }
            player.Stop();
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

        //static public void print(string str, int delay)
        //{
        //    typewriter.SoundLocation = Environment.CurrentDirectory + "/typewriter.wav";
        //    Thread skipThread = new Thread(skipText);
        //    typewriter.PlayLooping();
        //    textgap = delay;
        //    foreach (char c in str)
        //    {
        //        Console.Write(c);
        //        if (textgap != 0)
        //            Thread.Sleep(textgap);

        //    }
        //    typewriter.Stop();

        //}





    }
}

