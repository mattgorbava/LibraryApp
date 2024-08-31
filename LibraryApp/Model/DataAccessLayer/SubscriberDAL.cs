using LibraryApp.Model.Entities;
using Microsoft.Data.SqlClient;

namespace LibraryApp.Model.DataAccessLayer
{
    public class SubscriberDAL
    {
        public List<Subscriber> GetSubscribers()
        {
            var connection = DbHelper.Connection;
            List<Subscriber> subscribers = new List<Subscriber>();
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SelectAllSubscribersAlphabetically", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Subscriber subscriber = new Subscriber();
                    subscriber.PersonId = reader.GetInt32(0);
                    subscriber.Name = reader.GetString(1);
                    subscriber.CNP = reader.GetString(2);
                    subscriber.Address = reader.GetString(3);
                    subscriber.PhoneNumber = reader.GetString(4);
                    subscriber.IsRegistered = reader.GetBoolean(5);
                    subscribers.Add(subscriber);
                }
            }
            catch (Exception ex) { throw ex; }
            finally { connection.Close(); }

            return subscribers;
        }

        public Subscriber GetSubscriberById(int SubscriberId)
        {
            var connection = DbHelper.Connection;
            Subscriber subscriber = new Subscriber();
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SelectSubscriberById", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@PersonId", SubscriberId);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    subscriber.PersonId = reader.GetInt32(0);
                    subscriber.Name = reader.GetString(2);
                    subscriber.CNP = reader.GetString(1);
                    subscriber.Address = reader.GetString(3);
                    subscriber.PhoneNumber = reader.GetString(4);
                    subscriber.IsRegistered = reader.GetBoolean(5);
                }
            }
            catch (Exception ex) { throw ex; }
            finally { connection.Close(); }
            return subscriber;
        }

        public void AddSubscriber(Subscriber subscriber)
        {
            var connection = DbHelper.Connection;
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("AddSubscriberUpdated", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Name", subscriber.Name);
                command.Parameters.AddWithValue("@CNP", subscriber.CNP);
                command.Parameters.AddWithValue("@Address", subscriber.Address);
                command.Parameters.AddWithValue("@PhoneNumber", subscriber.PhoneNumber);
                command.ExecuteNonQuery();
            }
            catch (Exception ex) { throw ex; }
            finally { connection.Close(); }
        }

        public void EditSubscriber(Subscriber subscriber)
        {
            var connection = DbHelper.Connection;
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("EditSubscriber", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@PersonId", subscriber.PersonId);
                command.Parameters.AddWithValue("@CNP", subscriber.CNP);
                command.Parameters.AddWithValue("@Name", subscriber.Name);
                command.Parameters.AddWithValue("@Address", subscriber.Address);
                command.Parameters.AddWithValue("@PhoneNumber", subscriber.PhoneNumber);
                command.Parameters.AddWithValue("@IsRegistered", subscriber.IsRegistered);
                command.ExecuteNonQuery();
            }
            catch (Exception ex) { throw ex; }
            finally { connection.Close(); }
        }

        public void ToggleRegistered(Subscriber subscriber)
        {
            var connection = DbHelper.Connection;
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("ToggleRegisteredSubscriber", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@PersonId", subscriber.PersonId);
                command.ExecuteNonQuery();
            }
            catch(Exception ex) { throw ex; }
            finally { connection.Close(); }
        }

    }
}
