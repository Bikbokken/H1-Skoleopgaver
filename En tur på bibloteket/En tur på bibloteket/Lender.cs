using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace En_tur_på_bibloteket
{
    public class Lender
    {
        public Stack<Book> LendedBooks = new Stack<Book>();
        public string Name { get;set; }

        public Lender(string name)
        {
            Name = name;
        }

        /// <summary>
        /// Adds a book to the stack of lendedbooks.
        /// </summary>
        /// <param name="book">The book</param>
        public void LendBook(Book book) { LendedBooks.Push(book);}

        /// <summary>
        /// Get the next book in line
        /// </summary>
        /// <returns>Returns the book which is next in line</returns>
        public Book GetBook() { return LendedBooks.Peek(); }
       
        /// <summary>
        /// Get the number of lended books
        /// </summary>
        /// <returns>Returns the number of lendedbooks</returns>
        public int GetNumberOfLendedBooks(){return LendedBooks.Count();}

        /// <summary>
        /// Remove the first book in line.
        /// </summary>
        public void ScanBook(){LendedBooks.Pop();}

    }
}
