using LibraryApp.Model.Entities;
using Microsoft.Data.SqlClient;

namespace LibraryApp.Model.DataAccessLayer
{
    public class PersonnelDAL
    {
        public List<Personnel> GetAllPersonnel()
        {
            var connection = DbHelper.Connection;
            List<Personnel> personnel = new List<Personnel>();
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("GetAllRowsFromTable", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@TableName", "Personnel");
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Personnel currentPersonnel = new Personnel();
                    currentPersonnel.PersonnelId = reader.GetInt32(0);
                    currentPersonnel.Name = reader.GetString(1);
                    currentPersonnel.EmploymentDate = reader.GetDateTime(2);
                    currentPersonnel.IsDeregistered = reader.GetBoolean(3);
                    personnel.Add(currentPersonnel);
                }
            }
            catch (Exception ex) { throw ex; }
            finally { connection.Close(); }

            return personnel;
        }

        public void AddPersonnel(Personnel personnel)
        {
            var connection = DbHelper.Connection;
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("AddPersonnel", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Name", personnel.Name);
                command.Parameters.AddWithValue("@EmploymentDate", personnel.EmploymentDate);
                command.ExecuteNonQuery();
            }
            catch (Exception ex) { throw ex; }
            finally { connection.Close(); }
        }

        public void DeregisterPersonnel(Personnel personnel)
        {
            var connection = DbHelper.Connection;
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("DeregisterPersonnel", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@PersonnelId", personnel.PersonnelId);
                command.ExecuteNonQuery();
            }
            catch (Exception ex) { throw ex; }
            finally { connection.Close(); }
        }

        public void EditPersonnel(Personnel personnel)
        {
            var connection = DbHelper.Connection;
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("EditPersonnel", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@PersonnelId", personnel.PersonnelId);
                command.Parameters.AddWithValue("@Name", personnel.Name);
                command.Parameters.AddWithValue("@EmploymentDate", personnel.EmploymentDate);  
                command.Parameters.AddWithValue("@IsDeregistered", personnel.IsDeregistered);
                command.ExecuteNonQuery();
            }
            catch (Exception ex) { throw ex; }
            finally { connection.Close(); }
        }
    }
}
