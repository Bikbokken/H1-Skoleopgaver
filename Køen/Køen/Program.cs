using Køen;
using System.Security.Cryptography;

public class Program
{
    
    static void Main(string[] args)
    {
        QueueController queueController = new QueueController(); // Create Queue Controller
        bool isRunning = true;
        while(isRunning)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("==================================================");
            Console.WriteLine();
            Console.WriteLine("Klub Sindsyg Kø");
            Console.WriteLine();
            Console.WriteLine("==================================================");
            Console.WriteLine();
            Console.WriteLine("1. Tilføj gæst");
            Console.WriteLine("2. Fjern gæst");
            Console.WriteLine("3. Vis hvor mange som er i kø.");
            Console.WriteLine("4. Vis min max i køen.");
            Console.WriteLine("6. Print gæsteliste");
            Console.WriteLine("7. Exit");

            // Try to parse the byte - if true out to input
            if (Byte.TryParse(Console.ReadLine(), out byte input)) { 
                Console.Clear();
                switch(input) // Switch the input
                {
                    case 1:
                        Guest guest = AddNewGuest(); // Runs the AddNewGuest, which prompts the user for username and age
                        queueController.AddGuest(guest); // Adds the guest to the queue
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(guest.Name + " er blevet tilføjet til køen");
                        break;
                    case 2:
                        if (queueController.guests.Count > 0) // If there is more than on in the queue
                        {
                            Guest nextInLine = queueController.NextInLine(); // Get the next person in line
                            Console.WriteLine("Du kommer til at slette " + nextInLine.Name);
                            bool result = RemoveNextGuest(); // You sure?
                            if (result) // Yes
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine(nextInLine.Name + " er nu slettet");
                                queueController.RemoveNextInline(); // Remove the guest from the queue
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Afbryder sletning");
                            }
                        } else
                        {
                            Console.WriteLine("Der er ingen i kø");
                        }
                        break;
                    case 3:
                        int count = queueController.guests.Count;
                        if (count > 0) // Is there more than 0 in the queue
                        {
                            Console.WriteLine("Der er i øjeblikket: " + count + " i kø! ");
                        } else
                        {
                            Console.WriteLine("Der er ingen i kø");
                        }
                        break;
                    case 4:
                        if (queueController.guests.Count > 0) // ISt here more than 0 in the queue
                        {
                            Console.WriteLine("MIN Queue: " + queueController.guests.First().Name);
                            Console.WriteLine("MAX Queue: " + queueController.guests.Last().Name);
                        } else
                        {
                            Console.WriteLine("Der er ingen i kø");
                        }
                        break;
                    case 6:
                        PrintAllGuests(queueController.guests); //Runs the PrintAllGusts method
                        break;
                    case 7:
                        isRunning = false;
                        Console.WriteLine("Lukker.");
                        break;
                }
                Task.Delay(3000).Wait(); // Waits 3 seconds before continuing
            }
            Console.Clear();
        }
    }

    /// <summary>
    /// Prompt removal of the next guest in queue - the function only serves as a confirmation function.
    /// </summary>
    /// <returns>True if the user types 1, false if the user types anything else.</returns>
    static bool RemoveNextGuest()
    {
        Console.WriteLine("Er du sikker på at du ønsker at slette denne gæst? (Skriv 1 for ja)");
        byte choice = byte.Parse(Console.ReadLine());
        if(choice == 1)
        {
            return true;
        } else
        {
            return false;
        }
    }

    /// <summary>
    /// Prompts the user for name and age for the guest - and creates the guest object.
    /// </summary>
    /// <returns>Return the guest object</returns>
    static Guest AddNewGuest()
    {
        Console.Clear();
        Console.WriteLine("Hvad er navnet på gæsten du ønsker at oprette:");
        string name = Console.ReadLine();
        Console.WriteLine("Hvad er alderen på gæsten du ønsker at oprette?");
        byte age = Byte.Parse(Console.ReadLine());
        Guest guest = new(name, age);
        return guest;
    }

    /// <summary>
    /// Prints all the guests from the Guest queue from the parameter
    /// </summary>
    /// <param name="guests">Queue of Guest</param>
    /// <returns>Prints the guests</returns>
    static void PrintAllGuests(Queue<Guest> guests)
    {
        if(guests.Count > 0)
        {
            foreach(Guest guest in guests)
            {
                Console.WriteLine("Navn: " + guest.Name + " - Alder: " + guest.Age);
            }
        } else
        {
            Console.WriteLine("Der er ingen i kø");
        }

    }
}