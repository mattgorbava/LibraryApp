using LibraryApp.Model.Entities;
using Microsoft.Data.SqlClient;

namespace LibraryApp.Model.DataAccessLayer
{
    public class BookAuthorDAL
    {
        public List<BookAuthor> GetAllBookAuthors()
        {
            var connection = DbHelper.Connection;
            List<BookAuthor> bookAuthors = new List<BookAuthor>();
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("GetAllBookAuthors", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    BookAuthor bookAuthor = new BookAuthor();
                    bookAuthor.BookId = reader.GetString(0);
                    bookAuthor.AuthorId = reader.GetInt32(1);
                    bookAuthor.BorrowDate = reader.GetDateTime(2);
                    bookAuthors.Add(bookAuthor);
                }
            }
            catch (Exception ex) { throw ex; }
            finally { connection.Close(); }
            return bookAuthors;
        }

        public void AddBookAuthor(BookAuthor bookAuthor)
        {
            var connection = DbHelper.Connection;
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("AddBookAuthor", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@BookId", bookAuthor.BookId);
                command.Parameters.AddWithValue("@AuthorId", bookAuthor.AuthorId);
                command.Parameters.AddWithValue("@BorrowDate", DateTime.Now);
                command.ExecuteNonQuery();
            }
            catch (Exception ex) { throw ex; }
            finally { connection.Close(); }
        }

        public void DeleteBookAuthor(BookAuthor bookAuthor)
        {
            var connection = DbHelper.Connection;
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("DeleteBookAuthor", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@BookId", bookAuthor.BookId);
                command.Parameters.AddWithValue("@AuthorId", bookAuthor.AuthorId);
                command.ExecuteNonQuery();
            }
            catch (Exception ex) { throw ex; }
            finally { connection.Close(); }
        }
    }
}