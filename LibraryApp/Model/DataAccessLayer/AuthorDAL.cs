using LibraryApp.Model.Entities;
using Microsoft.Data.SqlClient;

namespace LibraryApp.Model.DataAccessLayer
{
    public class AuthorDAL
    {
        public List<Author> GetAuthors()
        {
            var connection = DbHelper.Connection;
            List<Author> authors = new List<Author>();
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SelectAuthors", connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Author author = new Author();
                    author.AuthorName = reader.GetString(0);
                    authors.Add(author);
                }
            }
            catch (Exception ex) { throw ex; }
            finally { connection.Close(); }
            return authors;
        }

        public void AddAuthor(Author author)
        {
            var connection = DbHelper.Connection;
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("AddAuthor", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@AuthorName", author.AuthorName);
                command.ExecuteNonQuery();
            }
            catch (Exception ex) { throw ex; }
            finally { connection.Close(); }
        }

        public void DeleteAuthor(Author author)
        {
            var connection = DbHelper.Connection;
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("DeleteAuthor", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@AuthorName", author.AuthorName);
                command.ExecuteNonQuery();
            }
            catch (Exception ex) { throw ex; }
            finally { connection.Close(); }
        }

        public void AddAuthorToBook(Author author, Book book)
        {
            var connection = DbHelper.Connection;
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("AddAuthorToBook", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@AuthorName", author.AuthorName);
                command.Parameters.AddWithValue("@BookId", book.BookId);
                command.ExecuteNonQuery();
            }
            catch (Exception ex) { throw ex; }
            finally { connection.Close(); }
        }

        public void RemoveAuthorFromBook(Author author, Book book)
        {
            var connection = DbHelper.Connection;
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("RemoveAuthorFromBook", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@AuthorName", author.AuthorName);
                command.Parameters.AddWithValue("@BookId", book.BookId);
                command.ExecuteNonQuery();
            }
            catch (Exception ex) { throw ex; }
            finally { connection.Close(); }

        }
    }
}
