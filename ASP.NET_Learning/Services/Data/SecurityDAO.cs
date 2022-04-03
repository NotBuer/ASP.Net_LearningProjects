using ASP.NET_Learning.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data;

namespace ASP.NET_Learning.Services.Data
{
    // Data Access Object
    public class SecurityDAO
    {

        private static readonly string connectionStr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ASP.NET_Learning;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        
        /// <summary>
        /// Get the user.
        /// </summary>
        /// <param name="user"> The data that the user provided in the login form. </param>
        /// <returns> The user from the DB. </returns>
        public UserModel LoginUser(UserModel user)
        {
            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                // Open the connection and create the sqlFetchQuery string in a prepared statement.
                connection.Open();
                string sqlFetchQuery = "SELECT * FROM dbo.Users WHERE CPF = @CPF AND Password = @Password COLLATE SQL_Latin1_General_CP1_CS_AS";

                // Create the SQL Fetch Command and set the query variables.
                SqlCommand fetchCommand = new SqlCommand(sqlFetchQuery, connection);
                fetchCommand.Parameters.Add("@CPF", SqlDbType.BigInt).Value = user.CPF;
                fetchCommand.Parameters.Add("@Password", SqlDbType.VarChar).Value = user.Password;

                // Create the reader.
                SqlDataReader reader = fetchCommand.ExecuteReader();

                // If is at least one row, return the user.
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        // Get the data from the reader, and passing it an int to find which column to look-up.
                        user.Id = reader.GetInt32(0);
                        user.Name = reader.GetString(1);
                        user.Age = reader.GetInt32(2);
                        user.CPF = reader.GetInt64(3);
                        user.Password = reader.GetString(4);

                        // Return the first user found matching the provided CPF and Password.
                        return user;
                    }
                }

                // Otherwise if no user found, return the default templater error user.
                return UserModel.UserTemplateError;
            }
        }
        

        /// <summary>
        /// Create the user, if the user not already exists.
        /// </summary>
        /// <param name="user"> The data that the user provided in the register form. </param>
        /// <returns> The created user data from the DB. </returns>
        public UserModel CreateUser(UserModel user)
        {
            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                // Open the connection to start operating in.
                connection.Open();

                // First try to fetch the user in the DB to see if this CPF is already registered
                string sqlFetchQuery = "SELECT * FROM dbo.Users WHERE CPF = @CPF";

                // Create a new SQLCommand and set the values inside the fetch query.
                SqlCommand fetchCommand = new SqlCommand(sqlFetchQuery, connection);
                fetchCommand.Parameters.Add("@CPF", SqlDbType.BigInt).Value = user.CPF;

                // Create the reader, and check if the provided CPF already exists in the DB.
                // If so, return to avoiding adding the same user CPF twice.
                SqlDataReader reader = fetchCommand.ExecuteReader();
                if (reader.HasRows)
                {
                    return UserModel.UserTemplateError;
                }
                
                // Ensure to close the data reader.
                reader.Close();

                // If the CPF was not found inside the DB, then proceed to create the query and try to create the user.
                string sqlInsertQuery = "INSERT INTO dbo.Users VALUES (@Name, @Age, @CPF, @Password)";

                // Create a new SQLCommand and set the values inside the insert query string.
                SqlCommand insertCommand = new SqlCommand(sqlInsertQuery, connection);
                insertCommand.Parameters.Add("@Name", SqlDbType.VarChar, 50).Value = user.Name;
                insertCommand.Parameters.Add("@Age", SqlDbType.Int).Value = user.Age;
                insertCommand.Parameters.Add("@CPF", SqlDbType.BigInt).Value = user.CPF;
                insertCommand.Parameters.Add("@Password", SqlDbType.VarChar, 50).Value = user.Password;

                // Get the Id of the user which was created.
                int Id = insertCommand.ExecuteNonQuery();
                user.Id = Id;

                // Return the user with the new ID value.
                return user;
            }
        }

    }
}