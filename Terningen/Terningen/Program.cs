Random random = new Random();
int dice = random.Next(1, 7);

if(dice== 1)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("Du slog 1");

} else if(dice== 2)
{
    Console.ForegroundColor = ConsoleColor.Blue;
    Console.WriteLine("Du slog 2");
}
else if (dice == 3)
{
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("Du slog 3");
}
else if (dice == 4)
{
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("Du slog 4");
}
else if (dice == 5)
{
    Console.ForegroundColor = ConsoleColor.Magenta;
    Console.WriteLine("Du slog 5");
}
else if (dice == 6)
{
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine("Du slog 6");
}