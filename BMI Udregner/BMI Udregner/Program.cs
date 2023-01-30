Console.WriteLine("Indtast din højde i cm");
double height = Double.Parse(Console.ReadLine());
Console.WriteLine("Indtast din vægt ");
double weight = Double.Parse(Console.ReadLine());

height /= 100;

double bmi = (weight / (height * height));


Console.WriteLine("Din bmi er " + bmi);

if (bmi > 16 && bmi < 18.5) {
    Console.WriteLine("Du er undervætig");
} else if(bmi > 18.5 && bmi < 24)
{
    Console.WriteLine("Du er normal vægtig");
}
else if (bmi > 24 && bmi < 30)
{
    Console.WriteLine("Du er over vægtig");
}
else if (bmi > 30 && bmi < 35)
{
    Console.WriteLine("Du første grads overvægtig");
}
else if (bmi > 35 && bmi < 40)
{
    Console.WriteLine("Du anden grads overvægtig");
}
else if (bmi < 40)
{
    Console.WriteLine("Du tredje grads overvægtig");
}
