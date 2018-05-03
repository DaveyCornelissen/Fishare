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
        public bool Create(User entity)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            using (SqlCommand command = new SqlCommand("dbo.CreateUserAccount", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@UserEmail", entity.UserEmail);
                command.Parameters.AddWithValue("@Password", entity.Password);
                command.Parameters.AddWithValue("@FirstName", entity.FirstName);
                command.Parameters.AddWithValue("@LastName", entity.LastName);
                command.Parameters.AddWithValue("@BirthDay", entity.BirthDay);
                command.Parameters.AddWithValue("@Phone", entity.PhoneNumber);

                try
                {
                    connection.Open();
                    //return true if account is created
                     int result = command.ExecuteNonQuery();

                    if (result == 0)
                    {
                        return false;
                    }
                    return true;
                }
                catch (Exception errorException)
                {
                    throw errorException;
                }
            }
        }

        public User Read(int Id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            using (SqlCommand command = new SqlCommand("dbo.GetUserProfile", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@UserId", Id);
                try
                {
                    connection.Open();

                    SqlDataReader dataReader = command.ExecuteReader();

                    dataReader.Read();

                    User user = new User
                    {
                        UserID = (int)dataReader["UserID"],
                        UserEmail = dataReader["UserEmail"].ToString(),
                        Password = dataReader["Password"].ToString(),
                        FirstName = dataReader["Firstname"].ToString(),
                        LastName = dataReader["Lastname"].ToString(),
                        PhoneNumber = dataReader["Phone"].ToString(),
                        PpPath = dataReader["User_photo_Path"].ToString(),
                        BirthDay = (DateTime)dataReader["BirthDay"],
                        Bio = dataReader["Bio"].ToString()
                    };

                    //for the next table
                    if (dataReader.NextResult())
                    {
                        List<Post> userPosts = new List<Post>();

                        while (dataReader.Read())
                        {
                            Post post = new Post
                            {
                                PostID = (int)dataReader["PostID"],
                                Title = dataReader["Title"].ToString(),
                                DateTime = (DateTime)dataReader["DateTime"],
                                PrimaryPhoto = dataReader["Path"].ToString()

                            };
                            userPosts.Add(post);
                        }

                        //set the new list to the user object
                        user.Posts = userPosts;

                    }

                    //for the next table
                    if (dataReader.NextResult())
                    {
                        dataReader.Read();

                        //set the totalfriends to the user object
                        user.TotalFriends = (int)dataReader["TotalFriends"];
                    }

                    return user;
                }
                catch (Exception errorException)
                {
                    throw errorException;
                }
            }
        }

        public bool Update(User entity)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            using (SqlCommand command = new SqlCommand("dbo.UpdateUserAccount", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@UserID", entity.UserID);
                command.Parameters.AddWithValue("@UserEmail", entity.UserEmail);
                command.Parameters.AddWithValue("@Password", entity.Password);
                command.Parameters.AddWithValue("@FirstName", entity.FirstName);
                command.Parameters.AddWithValue("@LastName", entity.LastName);
                //command.Parameters.AddWithValue("@BirthDay", entity.BirthDay);
                command.Parameters.AddWithValue("@Phone", entity.PhoneNumber);
                command.Parameters.AddWithValue("@Bio", entity.Bio);

                try
                {
                    connection.Open();
                    //return true if account is created
                    int result = command.ExecuteNonQuery();

                    if (result == 0)
                    {
                        return false;
                    }
                    return true;
                }
                catch (Exception errorException)
                {
                    throw errorException;
                }
            }
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
            using (SqlConnection connection = new SqlConnection(_connectionString))
            using (SqlCommand command = new SqlCommand("dbo.CheckLogin", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@Password", password);

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
            using (SqlConnection connection = new SqlConnection(_connectionString))
            using (SqlCommand command = new SqlCommand("dbo.CheckEmailExistence", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Email", email);

                try
                {
                    connection.Open();
                    SqlDataReader dataReader = command.ExecuteReader();

                    dataReader.Read();

                    if ((int)dataReader["TotalMatches"] != 0)
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

        public User GetCookieInfo(string email)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            using (SqlCommand command = new SqlCommand("dbo.GetCookieInfo", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Email", email);
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
                            UserID = (int)dataReader["UserID"],
                            FirstName = dataReader["Firstname"].ToString(),
                            PpPath = dataReader["User_Photo_Path"].ToString()
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
    }
}
