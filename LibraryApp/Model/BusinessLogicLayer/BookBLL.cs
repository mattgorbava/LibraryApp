using LibraryApp.Model.DataAccessLayer;
using LibraryApp.Model.Entities;
using System.Collections.ObjectModel;

namespace LibraryApp.Model.BusinessLogicLayer
{
    public class BookBLL
    {
        private readonly BookDAL bookDAL;

        public BookBLL()
        {
            bookDAL = new BookDAL();
        }

        public ObservableCollection<Book> GetBooks()
        {
            ObservableCollection<Book> books = new ObservableCollection<Book>();
            foreach (var book in bookDAL.GetBooks()) 
                books.Add(book);
            return books;
        }

        public void AddBook(Book book)
        {
            bookDAL.AddBook(book);
            //add BookAuthor entity
        }

        public void EditBook(Book book)
        {
            bookDAL.EditBook(book);
        }

        public void DeleteBook(Book book)
        {
            //check the book's authors
            //if they dont have any other books written, delete them
            bookDAL.DeleteBook(book);
        }

        public void LendBook(Book book, Subscriber subscriber)
        {
            bookDAL.LendBook(book, subscriber);
        }

        public void ReturnBook(Book book, Subscriber subscriber)
        {
            bookDAL.ReturnBook(book, subscriber);
        }

        public List<Book> SelectBorrowedBooks(Subscriber subscriber)
        {
            return bookDAL.SelectBorrowedBooks(subscriber);
        }

        public List<Book> SelectAvailableBooks(Subscriber subscriber)
        {
            return bookDAL.SelectAvailableBooks(subscriber);
        }
    }
}
