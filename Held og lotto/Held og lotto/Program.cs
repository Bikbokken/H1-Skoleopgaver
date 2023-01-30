
public class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        do
        {
            Random random = new Random();
            int randomNum = random.Next(1, 37);
            if (!numbers.Contains(randomNum))
            {
                numbers.Add(randomNum);
            }
        } while(numbers.Count < 7); 
       
        numbers.Sort();
        int joker = GetJoker(numbers);

        foreach(int i in numbers)
        {
            Console.ForegroundColor = ConsoleColor.White;
            if (i == joker)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            Console.Write(i);
            Console.Write(" ");
            Task.Delay(2000).Wait();
        }
    }
    static int GetJoker(List<int> numbers)
    {
        Random random = new Random();
        int randomNum = random.Next(0, numbers.Count());
        return numbers.ElementAt(randomNum);
    }
}
