
Console.WriteLine("Skriv Længde");
double length = Double.Parse(Console.ReadLine());

Console.WriteLine("Skriv bredde");
double width = Double.Parse(Console.ReadLine());

Console.WriteLine("Skriv højde");
double height = Double.Parse(Console.ReadLine());

double result = length * height * width;

Console.WriteLine("Rumfanget er: " + result);

