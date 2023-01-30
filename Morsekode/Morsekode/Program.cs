using System.Runtime.InteropServices;
using System.Security;

public class Program
{
    static void Main(string[] args)
    {
        while(true)
        {
            string morseCode = "";
            Console.WriteLine("Skriv det som du ønsker konveteret til mosekode:");
            char[] input = Console.ReadLine().ToCharArray();
            foreach(char ch in input) {
                morseCode += " " + GetMorse(ch) + " ";
            }
            Console.WriteLine(morseCode);
        }



    }

    static string GetMorse(char input)
    {
        switch(Char.ToUpper(input))
        {
            case 'A':
                return "* -";
            case 'B':
                return "- * * *";
            case 'C':
                return "- * - *";
            case 'D':
                return "- * *";
            case 'E':
                return "*";
            case 'F':
                return "* * - *";
            case 'G':
                return "- - *";
            case 'H':
                return "* * * *";
            case 'I':
                return "* *";
            case 'J':
                return "* - - -";
            case 'K':
                return "- * -";
            case 'L':
                return "* - * *";
            case 'M':
                return "- -";
            case 'N':
                return "- *";
            case 'O':
                return "- - -";
            case 'P':
                return "* - - *";
            case 'Q':
                return "- - * -";
            case 'R':
                return "* - *";
            case 'S':
                return "* * *";
            case 'T':
                return "-";
            case 'U':
                return "* * -";
            case 'V':
                return "* * * -";
            case 'W':
                return "* - -";
            case 'X':
                return "- * * -";
            case 'Y':
                return "- * - -";
            case 'Z':
                return "- - * *";
            case 'Ä':
            case 'Æ':
            case 'Ą':
                return "* - * -";
            case 'Ø':
            case 'Ó':
            case 'Ö':
                return "- - - *";
            case 'Å':
            case 'À':
                return "* - - * -";
            case '1':
                return "* - - - -";
            case '2':
                return "* * - - -";
            case '3':
                return "* * * - -";
            case '4':
                return "* * * * -";
            case '5':
                return "* * * * *";
            case '6':
                return "- * * * *";
            case '7':
                return "- - * * *";
            case '8':
                return "- - - * *";
            case '9':
                return "- - - - *";
            case '.':
                return "* - * - * -";
            case ',':
                return " - - * * - -";
            case ':':
                return "- - - * * *";
            case '?':
                return "* * - - * *";
            case '/':
                return "* * - - * *";
            case '-':
                return "- * * * * -";
            case '\'':
                return "* - - - - *";
            case '(':
                return "- * - - *";
            case ')':
                return "- * - - * -";
            case '"':
                return "* - * * - *";
            case '\n':
                return "* - * -";
            case '*':
                return "- * * -";
            case '@':
                return "* - - * - *";
           
        }
        return "";
    }
}