public class Program
{

public enum Colleges
{
    Gryffindor,
    Hufflepuff,
    Ravenclaw,
    Slytherin,
}

class SorteringsHat
{

    private Colleges _college;
    private Random random = new Random();

    public Colleges College { get { return _college; } }    


    public void GetCollege()
    {
        _college =(Colleges)random.Next(0, 4);
    }
}


    static void Main(string[] args)
    {
        Console.WriteLine("Du skal tilhøre:");
        SorteringsHat sorteringsHat = new SorteringsHat();
        sorteringsHat.GetCollege();
        Console.WriteLine(sorteringsHat.College);

    }


}
