using System.Reflection;
using System;
using System.Reflection.PortableExecutable;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;

public class Program
{
    enum LengthStatus
    {
        Kort = 0,
        Langt = 2,
        Ok = 1,
    }

    enum Stauses
    {
        Bad = 0,
        Ok = 1,
    }

    enum PasswordStrength
    {
        Bad = 0,
        Weak = 1,
        Strong = 2,
    }

    class Status
    {
        public LengthStatus Length { get; set; }
        public Stauses UpperLowerCase { get; set; }
        public Stauses CharacterAndInt { get; set; }
        public Stauses CharactersAndSpecials { get; set; }
        public Stauses SameCharacterRepeatedly { get; set; }
        public Stauses SequenceNumbers { get; set; }

    }


    static void Main(string[] args)
    {
        while (true)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Skriv dit password");
            
            Status status = new Status();
            char[] input = Console.ReadLine().ToCharArray();
            PasswordStrength finalResult = PasswordStrength.Bad;

            //Kører de forskellige checks.
            status.Length = CheckLength(input);
            status.UpperLowerCase = CheckLowerAndUpperCase(input);
            status.CharacterAndInt = CheckCharacterAndInt(input);
            status.CharactersAndSpecials = CheckCharactersAndSpecials(input);
            status.SameCharacterRepeatedly = CheckSameCharacterRepeatedly(input);
            status.SequenceNumbers = CheckSequenceNumbers(input);

            //Er alle de essentielle ting i orden?
            if ((int)status.Length == (int)Stauses.Ok
                && (int)status.UpperLowerCase == (int)Stauses.Ok
                && (int)status.CharacterAndInt == (int)Stauses.Ok
                && (int)status.CharactersAndSpecials == (int)Stauses.Ok) {
                finalResult = PasswordStrength.Strong; //Så er det stærkt
            }  

            //Er der nogle ting som kan gøre passwordet weak?
            if((int)status.SameCharacterRepeatedly == (int)Stauses.Bad || (int)status.SequenceNumbers == (int)Stauses.Bad) {
                if(finalResult == PasswordStrength.Strong)
                {
                    finalResult = PasswordStrength.Weak; //Sæt det til weak, HVIS passwordet er strong fra start.
                }
            }
            AlertUser(finalResult); //Informere useren omkring userens password.
            Console.ForegroundColor = ConsoleColor.Gray;
            Improvements(status); //Hvad kan useren gøre bedre?
            Console.WriteLine();
    
            //DEBUGGING INFO:
             // Type type = typeof(Status);
             // PropertyInfo[] properties = type.GetProperties();
             // foreach (PropertyInfo property in properties)
             // {
             //    Console.WriteLine("{0} = {1}", property.Name, property.GetValue(status, null));
             //  }
        }

    }


    /// <summary>
    /// Skriver eventuelle improvements til brugeren.
    /// </summary>
    /// <param name="input">Hele status objektet med de forskellige værdier</param>
    /// <returns></returns>
    static void Improvements(Status status)
    {
        if(status.Length == LengthStatus.Kort)
        {
            Console.WriteLine("  - Du har et for kort password");
        }
        if(status.Length == LengthStatus.Langt) {
            Console.WriteLine("  - Du har et for langt password");

        }
        if(status.UpperLowerCase == Stauses.Bad)
        {
            Console.WriteLine("  - Du skal bruge både UPPER og lower case karaktere");
        }
        if (status.CharacterAndInt == Stauses.Bad)
        {
            Console.WriteLine("  - Du skal både bruge karaktere og tal");
        }
        if (status.CharactersAndSpecials == Stauses.Bad)
        {
            Console.WriteLine("  - Du skal mindst have et specielt tegn");
        }
        if (status.SameCharacterRepeatedly == Stauses.Bad)
        {
            Console.WriteLine("  - Du må ikke have det samme bogstav eller tal 4 eller flere gange i træk (4444, AAAA, BBBB)");
        }
        if (status.SequenceNumbers == Stauses.Bad)
        {
            Console.WriteLine("  - Dine tal må ikke 'følges' (1234, 4567)");
        }

    }
    /// <summary>
    /// Skriver til useren, om useren har et dårligt, weak eller godt password
    /// </summary>
    /// <param name="passwordStrength">Tager i mod PasswordStrength</param>
    /// <returns></returns>
    static void AlertUser(PasswordStrength passwordStrength)
    {
        switch (passwordStrength)
        {
            case PasswordStrength.Bad:
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Du har et dårligt password");
                break;
            case PasswordStrength.Weak:
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Du har et weak password");
                break;
            case PasswordStrength.Strong:
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Du har et godt password");
                break;
        }
    }

    /// <summary>
    /// Tjekker om der er nogle numre som er efter hinanden 1234
    /// </summary>
    /// <param name="chars">Ét array af chars</param>
    /// <returns>Statuses.OK eller Statuses.Bad hvis der hhv. ingen sequence er og hvis der er.</returns>
    static Stauses CheckSequenceNumbers(char[] chars)
    {
        for (var i = 0; i < chars.Length - 3; i++)
        {
            if (Convert.ToInt32(chars[i + 1]) == Convert.ToInt32(chars[i]) +1 && Convert.ToInt32(chars[i+2]) == Convert.ToInt32(chars[i]) + 2 && Convert.ToInt32(chars[i +3]) == Convert.ToInt32(chars[i]) + 3)
            {
                return Stauses.Bad;
            }
        }
        return Stauses.Ok;
    }

    /// <summary>
    /// Tjekker om der er nogle karaktere som er det samme efter hinanden (HHHH)
    /// </summary>
    /// <param name="chars">Et array af charsr</param>
    /// <returns>Statuses.OK eller Statuses.Bad hvis der hhv. ingen karatere efter hinanden</returns>
    static Stauses CheckSameCharacterRepeatedly(char[] chars)
    {
        for (var i = 0; i < chars.Length - 3; i++)
        {
            if (chars[i + 1] == chars[i] && chars[i + 2] == chars[i] && chars[i + 3] == chars[i])
            {
                return Stauses.Bad;
            }
        }
        return Stauses.Ok;
    }


    /// <summary>
    /// Tjekker om der er mindst et specielt karakter.
    /// </summary>
    /// <param name="chars">Et array af chars</param>
    /// <returns>Statuses.OK eller Statuses.Bad hvis der hhv. er mindst en og hvis der ikke er en</returns>
    static Stauses CheckCharactersAndSpecials(char[] chars)
    {

        int specials = chars.Where(x=> !Char.IsWhiteSpace(x)).Count(x => Char.IsLetterOrDigit(x) == false); //IsLetterOrDigit tager også spaces, derfor skal !IsWhiteSpace på.
        if (specials >= 1) //Er der mere end et speciel karakter?
        {
            return Stauses.Ok;
        }
        return Stauses.Bad;
    }

    /// <summary>
    /// Tjekker hvis der er mindst et tal - et bogstav.
    /// </summary>
    /// <param name="chars">Et array af chars</param>
    /// <returns>Statuses.OK eller Statuses.Bad hvis der hhv. er mindst et tal og bogstav og hvis der ikke er en</returns>
    static Stauses CheckCharacterAndInt(char[] chars)
    {
        int ints = chars.Count(x => Char.IsNumber(x) == true);
        if (ints > 0 && chars.Length > ints) // Er der mere end et tal og er antallet af tal mindre end antallet af ord.
        {
            return Stauses.Ok;
        }
        return Stauses.Bad;
    }
    /// <summary>
    /// Tjekker om der mindst er et upper case karakter
    /// </summary>
    /// <param name="chars">Et array af chars</param>
    /// <returns>Statuses.OK eller Statuses.Bad hvis der hhv. er mindst er en og hvis der ikke er en</returns>

    static Stauses CheckLowerAndUpperCase(char[] chars)
    {
        int uppercase = chars.Count(x => Char.IsUpper(x) == true);
        if (uppercase > 0 && chars.Length > uppercase) // Er der mere end et uppercase char og er antallet af uppercase chars mindre end antallet af ord.
        {
            return Stauses.Ok;
        }
        return Stauses.Bad;

    }

    /// <summary>
    /// Tjekker om passwordets karaktere er mindst 12 og max 64
    /// </summary>
    /// <param name="chars">Et array af chars</param>
    /// <returns>LengthStatus.Kort, hvis passwordet er mindre en 12, LengthStatus.Langt, hvis passwordet er over 65, LengthStatus.Ok, hvis passwordet er i mellem 12 og 64 </returns>
    static LengthStatus CheckLength(char[] chars)
    {
        switch(chars.Length)
        {
            case int x when x < 12:
                return LengthStatus.Kort;
            case int x when x > 64:
                return LengthStatus.Langt;
            default:
                return LengthStatus.Ok;
        }
    }
}
