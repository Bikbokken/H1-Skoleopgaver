using System.Reflection.Emit;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;

public class Program
{
    class Stats
    {
        public static byte Matches;
    }
    static void Main(string[] args)
    {
        Stats.Matches = 7;
        Console.WriteLine("VELKOMMEN TIL NIM");

        do
        {
            byte input = PromptAmount();
            if(input > Stats.Matches)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Der er kun " + Stats.Matches + " på bordet!");
            } else if(input <= Stats.Matches)
            {
                if (input > 3)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Du må kun trække 3 af gangen!");
                }

                else if (input <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Du skal trække mindst en");
                }

                else if (input <= 3)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Du trak " + input + " tændstikker");
                    if ((Stats.Matches - input) == 1)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("Du vandt!");
                        return;
                    }
                    Stats.Matches = (byte) (Stats.Matches - input);
                    byte computerNum = MakeComputerTake();
                    ProcessComputerTake(computerNum);

                }
            }
            ResetColor();
        } while (Stats.Matches > 1);
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine("Spillet er slut");

    }

    static void ProcessComputerTake(byte number)
    {
        Stats.Matches = (byte)(Stats.Matches - number);

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Jeg trækker " + number);
        if(Stats.Matches == 1)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Du tabte!");
        }
    }

    static byte MakeComputerTake()
    {
        while(true)
        {
            Random random = new Random();
            int randomInt = random.Next(1, 4);
            if (randomInt <= Stats.Matches -1)
            {
                return (byte)randomInt;
            }
        }
    }
    static byte PromptAmount()
    {
        byte input;
        while(true)
        {

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Der er " + Stats.Matches + " tændstikker på bordet lige nu.");
            Console.WriteLine("Skriv hvor mange tændstikker du ønsker at trække - maks 3!");
            ResetColor();
            try
            {
                input = byte.Parse(Console.ReadLine());
                return input;
            } catch(Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Det skal være et nummer!");
            }
        }
    }
    static void ResetColor()
    {
        Console.ForegroundColor = ConsoleColor.White;
    }
}