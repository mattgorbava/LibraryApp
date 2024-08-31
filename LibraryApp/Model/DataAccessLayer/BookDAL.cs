using LibraryApp.Model.Entities;
using Microsoft.Data.SqlClient;

namespace LibraryApp.Model.DataAccessLayer
{
    public class BookDAL
    {
        public List<Book> GetBooks()
        {
            var connection = DbHelper.Connection;
            List<Book> books = new List<Book>();
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SelectAllBooks", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Book book = new Book();
                    book.BookId = reader.GetString(0);
                    book.Title = reader.GetString(1);
                    book.ReleaseYear = reader.GetInt32(2);
                    book.Publisher = reader.GetString(3);
                    book.FieldOfInterest = reader.GetString(4);
                    book.IsLost = reader.GetBoolean(5);
                    book.IsLendable = reader.GetBoolean(6);
                    book.IsLent= reader.GetBoolean(7);
                    books.Add(book);
                }
            }
            catch (Exception ex) { throw ex; }
            finally { connection.Close(); }

            return books;
        }

        public Book GetBookById(int BookId)
        {
            var connection = DbHelper.Connection;
            Book book = new Book();
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SelectBookById", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@BookId", BookId);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    book.BookId = reader.GetString(0);
                    book.Title = reader.GetString(1);
                    book.ReleaseYear = reader.GetInt32(2);
                    book.Publisher = reader.GetString(3);
                    book.FieldOfInterest = reader.GetString(4);
                    book.IsLost = reader.GetBoolean(5);
                    book.IsLendable = reader.GetBoolean(6);
                }
            }
            catch (Exception ex) { throw ex; }
            finally { connection.Close(); }
            return book;
        }
        public void AddBook(Book book)
        {
            var connection = DbHelper.Connection;
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("AddBook", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@BookId", book.BookId);
                command.Parameters.AddWithValue("@Title", book.Title);
                command.Parameters.AddWithValue("@ReleaseYear", book.ReleaseYear);
                command.Parameters.AddWithValue("@Publisher", book.Publisher);
                command.Parameters.AddWithValue("@FieldOfInterest", book.FieldOfInterest);
                command.ExecuteNonQuery();
            }
            catch(Exception ex) { throw ex; }
            finally { connection.Close(); }
        }

        public void EditBook(Book book)
        {
            var connection = DbHelper.Connection;
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("EditBook", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@BookId", book.BookId);
                command.Parameters.AddWithValue("@Title", book.Title);
                command.Parameters.AddWithValue("@ReleaseYear", book.ReleaseYear);
                command.Parameters.AddWithValue("@Publisher", book.Publisher);
                command.Parameters.AddWithValue("@FieldOfInterest", book.FieldOfInterest);
                command.Parameters.AddWithValue("@IsLendable", book.IsLendable);
                command.Parameters.AddWithValue("@IsLost", book.IsLost);
                command.Parameters.AddWithValue("@IsLent", book.IsLent);
                command.ExecuteNonQuery();
            }
            catch (Exception ex) { throw ex; }
            finally { connection.Close(); }
        }

        public void DeleteBook(Book book)
        {
            var connection = DbHelper.Connection;
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("DeleteBook", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@BookId", book.BookId);
                command.ExecuteNonQuery();
            }
            catch (Exception ex) { throw ex; }
            finally { connection.Close(); }
        }

        public void LendBook(Book book, Subscriber subscriber)
        {
            var connection = DbHelper.Connection;
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("LendBook", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@BookId", book.BookId);
                command.Parameters.AddWithValue("@PersonId", subscriber.PersonId);
                command.ExecuteNonQuery();
            }
            catch (Exception ex) { throw ex; }
            finally { connection.Close(); }
        }

        public void ReturnBook(Book book, Subscriber subscriber)
        {
            var connection = DbHelper.Connection;
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("ReturnBook", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@BookId", book.BookId);
                command.Parameters.AddWithValue("@PersonId", subscriber.PersonId);
                command.ExecuteNonQuery();
            }
            catch (Exception ex) { throw ex; }
            finally { connection.Close(); }
        }

        public List<Book> SelectBorrowedBooks(Subscriber subscriber)
        {
            var connection = DbHelper.Connection;
            List<Book> books = new List<Book>();
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SelectBorrowedBooks", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@PersonId", subscriber.PersonId);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Book book = new Book();
                    book.BookId = reader.GetString(0);
                    book.Title = reader.GetString(1);
                    book.ReleaseYear = reader.GetInt32(2);
                    book.Publisher = reader.GetString(3);
                    book.FieldOfInterest = reader.GetString(4);
                    book.IsLost = reader.GetBoolean(5);
                    book.IsLendable = reader.GetBoolean(6);
                    books.Add(book);
                }
            }
            catch (Exception ex) { throw ex; }
            finally { connection.Close(); }

            return books;
        }

        public List<Book> SelectAvailableBooks()
        {
            var connection = DbHelper.Connection;
            List<Book> books = new List<Book>();
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SelectAvailableBooks", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Book book = new Book();
                    book.BookId = reader.GetString(0);
                    book.Title = reader.GetString(1);
                    book.ReleaseYear = reader.GetInt32(2);
                    book.Publisher = reader.GetString(3);
                    book.FieldOfInterest = reader.GetString(4);
                    book.IsLost = reader.GetBoolean(5);
                    book.IsLendable = reader.GetBoolean(6);
                    books.Add(book);
                }
            }
            catch (Exception ex) { throw ex; }
            finally { connection.Close(); }

            return books;
        }
    }

}



