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
            string InsertUserQuery =
                "INSERT INTO [User] (Username, UserEmail, Password, FirstName, LastName, BirthDay, Phone) VALUES (@1, @2, @3, @4, @5, @6, @7)";

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
                    command.ExecuteNonQuery();
                    return true;
                }
                catch (Exception)
                {
                    //if insert failed
                    return false;
                }
            }
        }

        //TODO Cant reach the other recieved tabels 
        public User Read(int Id)
        {
            //string getAccountQuery = ;

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
                        UserName = dataReader["UserName"].ToString(),
                        UserEmail = dataReader["UserEmail"].ToString(),
                        FirstName = dataReader["Firstname"].ToString(),
                        LastName = dataReader["Lastname"].ToString(),
                        PhoneNumber = dataReader["Phone"].ToString(),
                        PpPath = dataReader["User_photo_Path"].ToString(),
                        Bio = dataReader["Bio"].ToString(),
                        TotalFriends = (int)dataReader["TotalFriends"]
                    };

                    int Posts = Convert.ToInt16(dataReader["PostID"]);

                    if (Posts != 0)
                    {
                        List<Post> userPosts = new List<Post>();

                        while (dataReader.Read())
                        {
                            Post post = new Post
                            {
                                PostID = (int)dataReader["PostID"],
                                Title = dataReader["Title"].ToString(),
                                //DateTime = (DateTime)dataReader["DateTime"],
                                PrimaryPhoto = dataReader["Path"].ToString()

                            };
                            userPosts.Add(post);
                        }

                        //set the new list to the user object
                        user.Posts = userPosts;

                    }

                    return user;
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

        public User GetCookieInfo(string email)
        {
            string getAccountIDQuery = "Select UserID, UserName From [User] Where UserEmail=@1";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            using (SqlCommand command = new SqlCommand(getAccountIDQuery, connection))
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
