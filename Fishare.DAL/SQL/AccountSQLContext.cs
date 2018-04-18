using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;
using Fishare.Model;
using Fishare.Repository.Interface;

namespace Fishare.DAL.SQL
{
    public class AccountSQLContext : IAccountRepository
    {
        private readonly string _connectionString;

        public AccountSQLContext(string connectionString)
        {
            this._connectionString = connectionString;
        }

        /// <summary>
        /// Create an new user in the database
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool create(User entity)
        {
            string InsertUserQuery = "INSERT INTO [User] (Username, UserEmail, Password, FirstName, LastName, BirthDay, Phone) VALUES (@1, @2, @3, @4, @5, @6, @7)";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            using (SqlCommand command = new SqlCommand(InsertUserQuery, connection))
            {
                command.Parameters.AddWithValue("@1", entity.UserName);
                command.Parameters.AddWithValue("@2", entity.UserEmail);
                command.Parameters.AddWithValue("@3", entity.Password);
                command.Parameters.AddWithValue("@4", entity.FirstName);
                command.Parameters.AddWithValue("@5", entity.LastName);
                command.Parameters.AddWithValue("@6", DateTime.Now);
                command.Parameters.AddWithValue("@7", entity.PhoneNumber);
                //command.Parameters.AddWithValue("@8", "test");

                connection.Open();

                try
                {
                    //return true if account is created
                    command.ExecuteReader();
                    return true;
                }
                catch(Exception)
                {
                    //if insert failed
                    return false;
                }
            }
        }

        /// <summary>
        /// Get all the user properties by the email.
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public User Read(string email)
        {
            string existAccountQuery = "Select UserID, UserName, UserEmail, Firstname, Lastname, Birthday, Phone From [User] Where UserEmail=@1";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            using (SqlCommand command = new SqlCommand(existAccountQuery, connection))
            {

                command.Parameters.AddWithValue("@1", email);
                try
                {
                    connection.Open();

                    var result = command.ExecuteScalar();

                    if (result != null)
                    {
                        SqlDataReader dataReader = command.ExecuteReader();

                        dataReader.Read();

                        User User = new User
                        {
                            UserID = dataReader.GetInt32(0),
                            UserName = dataReader.GetString(1),
                            UserEmail = dataReader.GetString(2),
                            FirstName = dataReader.GetString(3),
                            LastName = dataReader.GetString(4),
                            BirthDay = dataReader.GetString(5),
                            PhoneNumber = dataReader.GetString(6),
                            //PpPath = dataReader.GetString(7)
                        };

                        return User;
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (Exception errorException)
                {
                    throw errorException;
                }
            }
        }

        public bool Update()
        {
            throw new NotImplementedException();
        }

        public bool Delete()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Check if the email and password exist to an user.
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool CheckLogin(string email, string password)
        {
            
            string checkLoginQuery = "Select UserEmail From [User] Where UserEmail=@1 And Password=@2";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            using (SqlCommand command = new SqlCommand(checkLoginQuery, connection))
            {

                command.Parameters.AddWithValue("@1", email);
                command.Parameters.AddWithValue("@2", password);

                try
                {
                    connection.Open();

                    var result = command.ExecuteScalar();

                    if (result == null)
                    {
                        return false;
                    }
                    else
                    {
                       return true;
                    }
                }
                catch (Exception errorException)
                {
                    throw errorException;
                }
            }
        }

        /// <summary>
        /// check if the new email adress not already exist.
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public bool Exist(string email)
        {
            string existAccountQuery = "Select UserEmail From [User] Where UserEmail=@1";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            using (SqlCommand command = new SqlCommand(existAccountQuery, connection))
            {
                command.Parameters.AddWithValue("@1", email);

                try
                {
                    connection.Open();

                    var result = command.ExecuteScalar();

                    if (result != null)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception errorException)
                {
                    throw errorException;
                }
            }
        }
    }
}
