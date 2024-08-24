using LibraryApp.Model.DataAccessLayer;
using LibraryApp.Model.Entities;
using Microsoft.Data.SqlClient;
using System.Collections.ObjectModel;

namespace LibraryApp.Model.BusinessLogicLayer
{
    class BookAuthorBLL
    {
        private readonly BookAuthorDAL bookAuthorDAL;

        public BookAuthorBLL()
        {
            bookAuthorDAL = new BookAuthorDAL();
        }

        public ObservableCollection<BookAuthor> GetBookAuthors()
        {
            ObservableCollection<BookAuthor> bookAuthors = new ObservableCollection<BookAuthor>();
            foreach (var bookAuthor in bookAuthorDAL.GetAllBookAuthors())
                bookAuthors.Add(bookAuthor);
            return bookAuthors;
        }

        public void AddBookAuthor(BookAuthor bookAuthor)
        {
            bookAuthorDAL.AddBookAuthor(bookAuthor);
        }

        public void RemoveBookAuthor(BookAuthor bookAuthor)
        {
            bookAuthorDAL.DeleteBookAuthor(bookAuthor);
        }
    }
}
