using Book_Library;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Book_Rest_API.Managers
{
    public class BooksManager
    {
        //private static string _nextISBN13;

        private static readonly List<Book> Data = new List<Book>
        {
            new Book { ISBN13 = "978-0-000-00000-1", Title = "Beauty and the beast", Author = "Maria", PageNumber = 200 },
            new Book{ISBN13 = "978-0-000-00000-2", Title = "Learning C#", Author = "Andreas", PageNumber = 200}
        
    };

        public List<Book> GetAll()
        {
            return new List<Book>(Data);
            // copy constructor
            // Callers should no get a reference to the Data object, but rather get a copy
        }

        public Book GetById(string in_ISBN13)
        {
            return Data.Find(book => book.ISBN13 == in_ISBN13);
        }

        public Book Add(Book newBook)
        {
            //newBook.ISBN13 = _nextISBN13;//++ inakataa
            Data.Add(newBook);
            return newBook;
        }


        public Book Delete(string in_ISBN13)
        {
            Book book = Data.Find(book1 => book1.ISBN13 == in_ISBN13);
            if (book == null) return null;
            Data.Remove(book);
            return book;
        }
        public Book Update(string in_ISBN13, Book updates)
        {
            Book book = Data.Find(book1 => book1.ISBN13 == in_ISBN13);
            if (book == null) return null;
            book.Title = updates.Title;
            book.Author= updates.Author;
            book.PageNumber = updates.PageNumber;
            return book;
        }

    }




}

