int height = 8;
int dots = 1;
int spaces = 15;

for (int i = 0; i < height; i++)
{
    for (int x = 0; x < spaces; x++)
    {
        Console.Write(" ");
    }
    for (int y = 0; y < dots; y++)
    {
        if(i%2 != 0) { // er laget vi er på et odd number (altså hver anden)
            if (y % 2 != 0) //er det nummer af dot vi er nået til et odd numer (igen hver anden)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
        }
        Console.Write("* ");
        Console.ForegroundColor = ConsoleColor.White;
    }
    spaces = spaces-2;
    dots = dots+2; 
    Console.WriteLine(" ");
}