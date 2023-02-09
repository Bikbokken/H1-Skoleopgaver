using En_tur_på_bibloteket;

public class Program
{
    static void Main(string[] args)
    {
        LibraryController library = new LibraryController(); // Creates a libary with books
        Lender lender = new Lender("Benjamin"); // Creates a lender
        bool isRunning = true;
        while (isRunning)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Velkommen til Benjamin Bibloteket");
            Console.WriteLine();
            Console.WriteLine("Tast 1 for at vælge nogle bøger");
            Console.WriteLine("Tast 2 for at scanne dine bøger");
            Console.WriteLine("Tast 7 for at lukke");
            Console.WriteLine();
            if (Byte.TryParse(Console.ReadLine(), out byte input))
            {
                Console.Clear();
                switch (input) // Switch the input
                {
                    case 1:
                        bool loanBooks = true;
                        while(loanBooks)
                        {
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.WriteLine("Velkommen til lån af bøger:");
                            if(library.GetNumberAvaliableBooks() > 0) // If the total amount of books in the libary is over 0
                            {
                                Console.WriteLine("Du har mulighed for at låne følgende bøger:");
                                Console.ForegroundColor = ConsoleColor.Green;
                                foreach (Book book in library.GetAllBooksAvaliable()) // Loops through all avaliable books
                                {
                                    Console.WriteLine(book.ToString());
                                }
                                Console.ForegroundColor = ConsoleColor.Gray;
                                Console.WriteLine();
                                Console.WriteLine("Skriv IDet på bogen du ønsker at låne. 0 for at afslutte.");
                                if (Byte.TryParse(Console.ReadLine(), out byte bookId)) // Type the book id of the book you want to lend
                                {
                                    if (bookId == 0)
                                    {
                                        loanBooks = false;
                                    }
                                    if(library.DoesBookExistById(bookId))
                                    {
                                        lender.LendBook(library.GetBookById(bookId)); // Add the book to the lender's stack
                                        library.SetBooksAsLendById(bookId); // Set the books as lend in the library.
                                    }
                                }
                            } else // There is no more books to lend
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Der er desværre ingen bøger tilbage på hylderne");
                                Task.Delay(2000).Wait();
                                loanBooks = false;
                            }
                            Console.Clear();
                           
                        }
                        break;
                    case 2:
                        bool scanBooks = true;
                        while(scanBooks)
                        {
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.WriteLine("Velkommen til scanning af bøger:");
                            Console.ForegroundColor = ConsoleColor.Green;
                            if(lender.GetNumberOfLendedBooks() > 0) //  If the total amount of books in the libary is over 0
                            {
                                Book nextBook = lender.GetBook(); // Get the next book in the stack
                                Console.WriteLine("Du mangler at scanne:");
                                Console.WriteLine(nextBook.ToString());
                                Console.ForegroundColor = ConsoleColor.Gray;
                                Console.WriteLine("Tryk ENTER for at skanne - Tryk BACKSCAPE for at aflevere bogen tilbage.");
                                ConsoleKeyInfo consoleKey = Console.ReadKey();
                                if(consoleKey.Key == ConsoleKey.Enter) // If the key entered is enter
                                {
                                    lender.ScanBook(); // Remove the first book in the stack
                                } else if(consoleKey.Key == ConsoleKey.Backspace)
                                {
                                    library.SetBooksAsAvaliableById(nextBook.Id); // Set the book as avaliable again.
                                    lender.ScanBook(); // Remove the first vook in the stack
                                } else
                                {
                                    scanBooks = false;
                                    Task.Delay(2000).Wait();
                                }
                            } else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Du har ikke flere valgte bøger");
                                scanBooks = false;
                                Task.Delay(2000).Wait();
                            }
                            Console.Clear();
                            
                        }
                        break;
                    case 7:
                        isRunning = false;
                        break;
                }
                Console.Clear();

            }
        }
    }
}