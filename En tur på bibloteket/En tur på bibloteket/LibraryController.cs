using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace En_tur_på_bibloteket
{
    public class LibraryController
    {
        public List<Book> Books = new List<Book>();

        /// <summary>
        /// Add a book
        /// </summary>
        public void AddBook(Book book)
        {
            book.Id = Books.Count > 0 ? Books.Max(x => x.Id) + 1 : 1; // Gets the next avaliable ID to the book
            Books.Add(book);
        }

        public LibraryController() // Constructor
        {
            AddBook(new Book("EOW", "Benjamin Burek", Publisher.Gyldendal, 100));
            AddBook(new Book("Simon", "Simon Burek", Publisher.Gyldendal, 120));
            AddBook(new Book("C# Programmering", "Eow Burek", Publisher.Benjamin, 10));
            AddBook(new Book("Python Programmering", "Henrik Du ", Publisher.Gyldendal, 200));
            AddBook(new Book("Java Programmering", "Tomas Hen", Publisher.Benjamin, 150));
            AddBook(new Book("JavaScript Programmering", "Lolol", Publisher.Gyldendal, 128));
        }

        /// <summary>
        /// Get a book by id
        /// </summary>
        /// <param name="Book">Book</param>
        /// <returns>Returns the book with the specificed ID</returns>
        public Book GetBookById(int bookId){return Books.Where(x=>x.Id == bookId).FirstOrDefault();} // Returns the book with the id specificed

        /// <summary>
        /// Does the book exist by the id
        /// </summary>
        /// <param name="bookId">Book ID</param>
        /// <returns>Returns true if the book exist, false if it doesn't</returns>
        public bool DoesBookExistById(int bookId){return Books.Any(x => x.Id == bookId);}

        /// <summary>
        /// Set the book by id to lend in the system
        /// </summary>
        /// <param name="bookId">Book ID</param>
        public void SetBooksAsLendById(int bookId) {Books.Where(x => x.Id == bookId).First().Avaliabliy = Status.Lend;}

        /// <summary>
        /// Set the book by id to avaliable in the system
        /// </summary>
        /// <param name="bookId">Book Id</param>
        public void SetBooksAsAvaliableById(int bookId){Books.Where(x => x.Id == bookId).First().Avaliabliy = Status.Avaliable;}
        
        /// <summary>
        /// Get all the books with the status "Avaliable"
        /// </summary>
        /// <returns>Returns a list of books, which are Avaliable</returns>
        public List<Book> GetAllBooksAvaliable(){return Books.Where(x => x.Avaliabliy == Status.Avaliable).ToList();}

        /// <summary>
        /// Get the number of books with the status "Avaliable"
        /// </summary>
        /// <returns>Returns the number of books with the status "Avaliable".</returns>
        public int GetNumberAvaliableBooks(){return Books.Where(x => x.Avaliabliy == Status.Avaliable).ToList().Count;}


    }
}
