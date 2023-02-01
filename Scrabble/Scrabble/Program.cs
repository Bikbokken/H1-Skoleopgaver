using System.Runtime.InteropServices;
using System.Security;

public class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            int points = 0;
            Console.WriteLine("Skriv det som du ønsker konveteret til points:");
            char[] input = Console.ReadLine().ToCharArray(); //Laver inputtet om til et char array
            foreach (char ch in input) // Looper igennem alle chars i char arrayet.
            {
                points += GetPoint(ch); // Henter antallet af points for det givne ord og tilføjer den til den summerede points.
            }
            Console.WriteLine("Det giver i alt: " + points + " points!");
        }
    }

    /// <summary>
    /// Get the point of the input char.
    /// </summary>
    /// <param name="input">en character input</param>
    /// <returns>A byte representing point of the character.</returns>
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
        return 0; // Matcher characteren ikke en af de ovenstående, så skal den blot returnere 0.
    }
}