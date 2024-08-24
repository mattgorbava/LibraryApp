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
                SqlCommand command = new SqlCommand("GetAllRowsFromTable", connection);
                command.Parameters.AddWithValue("@Table", "Author");
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Author author = new Author();
                    author.AuthorId = reader.GetInt32(0);
                    author.Name = reader.GetString(1);
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
                command.Parameters.AddWithValue("@Name", author.Name);
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
                command.Parameters.AddWithValue("@AuthorId", author.AuthorId);
                command.ExecuteNonQuery();
            }
            catch (Exception ex) { throw ex; }
            finally { connection.Close(); }
        }
    }

}
