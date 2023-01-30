Console.WriteLine("Skriv celius");
double celcius = double.Parse(Console.ReadLine());

double fahrenheit = (celcius * 1.8) + 32;
double reamur = celcius * 0.8;

Console.WriteLine("CELCIUS " + celcius);
Console.WriteLine("REAMUR " + reamur);
Console.WriteLine("FAHRENHEIT " + fahrenheit);