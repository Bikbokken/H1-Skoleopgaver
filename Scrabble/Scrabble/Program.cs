using System.Runtime.InteropServices;
using System.Security;

public class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            string words = "";
            int points = 0;
            Console.WriteLine("Skriv det som du ønsker konveteret til points:");
            char[] input = Console.ReadLine().ToCharArray();
            foreach (char ch in input)
            {
                points += GetPoint(ch); // Henter antallet af points for det givne ord og tilføjer den til den summerede points.
            }
            Console.WriteLine("Det giver i alt: " + points + " points!");
        }
    }

    static byte GetPoint(char input)
    {
        switch (Char.ToUpper(input))
        {
            case 'E':
            case 'A':
            case 'N':
            case 'R':
                return 1;
            case 'D':
            case 'L':
            case 'O':
            case 'S':
            case 'T':
                return 2;
            case 'B':
            case 'I':
            case 'K':
            case 'F':
            case 'G':
            case 'M':
            case 'U':
            case 'V':
                return 3;
            case 'H':
            case 'J':
            case 'P':
            case 'Y':
            case 'Æ':
            case 'Ø':
            case 'Å':
                return 4;
            case 'C':
            case 'X':
            case 'Z':
            case 'W':
            case 'Q':
                return 8;
        }
        return 0;
    }
}