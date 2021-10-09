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
        #region Initializing some books 
        private static readonly List<Book> Data = new List<Book>
        {
            new Book { ISBN13 = "978-0-000-00000-1", Title = "Beauty and the beast", Author = "Maria", PageNumber = 200 },
            new Book{ISBN13 = "978-0-000-00000-2", Title = "Learning C#", Author = "Andreas", PageNumber = 200}

        };
        #endregion

        #region Method:GetAll()
        /// <summary>
        ///Displays the collection of all the books stored in the server
        ///   // The Callers should no get a reference to the Data object, but rather get a copy
        /// </summary>
        /// <returns></returns>
        public List<Book> GetAll()
        {
            return new List<Book>(Data);
        }
        #endregion

        #region Method:GetById()
        /// <summary>
        /// The caller can ask for a specific book by typing in the Id
        /// 
        /// </summary>
        /// <param name="inIsbn13"></param>
        /// <returns>The book with the id  the callertyped in  is returned </returns>
        public Book GetById(string inIsbn13)
        {
            return Data.Find(book => book.ISBN13 == inIsbn13);
        }


        #endregion

        #region Method: Add()
        /// <summary>
        /// A new book can be added to the data collection
        /// </summary>
        /// <param name="newBook"></param>
        /// <returns>The new book thst has been added is returned</returns>
        public Book Add(Book newBook)
        {

            Data.Add(newBook);
            return newBook;
        }
        #endregion

        #region Method: Delete()
        /// <summary>
        /// A specific book with a specific Id can be deleted from the collection
        /// </summary>
        /// <param name="inIsbn13"></param>
        /// <returns>The book that has been deleted is returned</returns>
        public Book Delete(string inIsbn13)
        {
            Book book = Data.Find(book1 => book1.ISBN13 == inIsbn13);
            if (book == null) return null;
            Data.Remove(book);
            return book;
        }
        #endregion

        #region Method: Update()
        /// <summary>
        /// A specific book can be updated. The Id has to be specified first, so that we can get the book, then update it
        /// </summary>
        /// <param name="inIsbn13">We need an ID so that we can know what book we want to update.</param>
        /// <param name="updates">The update book is returned</param>
        /// <returns></returns>
        public Book Update(string inIsbn13, Book updates)
        {
            Book book = Data.Find(book1 => book1.ISBN13 == inIsbn13);
            if (book == null) return null;
            book.Title = updates.Title;
            book.Author = updates.Author;
            book.PageNumber = updates.PageNumber;
            return book;
        }

        #endregion

    }
}

