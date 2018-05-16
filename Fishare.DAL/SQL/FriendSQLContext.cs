using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq.Expressions;
using Fishare.Model;
using Fishare.Repository.Interface;

namespace Fishare.Logic
{
    public class FriendSQLContext : IFriendsRepository
    {
        private string connectionString;

        public FriendSQLContext(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public bool Create(Friend entity)
        {
            throw new System.NotImplementedException();
        }

        public Friend Read(int Id)
        {
            throw new System.NotImplementedException();
        }

        public bool Update(Friend entity)
        {
            throw new System.NotImplementedException();
        }

        public bool Delete()
        {
            throw new System.NotImplementedException();
        }

        public bool Block(int FriendId)
        {
            throw new System.NotImplementedException();
        }

        public List<Friend> GetAcceptedFriends(int userId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand("dbo.GetAcceptedFriends", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@UserId", userId);
                try
                {
                    connection.Open();

                    SqlDataReader dataReader = command.ExecuteReader();

                    List<Friend> friends = new List<Friend>();

                    while (dataReader.Read())
                    {
                        User friendEntity = new User
                        {
                            UserID = (int) dataReader["UserID"],
                            FirstName = dataReader["Firstname"].ToString(),
                            LastName = dataReader["Lastname"].ToString(),
                            PpPath = dataReader["User_photo_Path"].ToString()
                        };

                        Friend friend = new Friend
                        {
                            FriendEntity = friendEntity,
                            ActionId = (int) dataReader["Action_User_ID"],
                            Status = Friend.eStatus.Accept
                        };

                        if ((int) dataReader["User_One_ID"] == userId)
                        {
                            friend.UserId = (int) dataReader["User_One_ID"];
                        }
                        else
                        {
                            friend.UserId = (int) dataReader["User_Two_ID"];
                        }

                        friends.Add(friend);
                    }

                    return friends;
                }
                catch (Exception errorException)
                {
                    throw errorException;
                }
            }
        }

        public List<Friend> GetPendingFriends(int userId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand("dbo.GetPendingFriends", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@UserId", userId);
                try
                {
                    connection.Open();

                    SqlDataReader dataReader = command.ExecuteReader();

                    List<Friend> pendingFriends = new List<Friend>();

                    while (dataReader.Read())
                    {
                        User friendEntity = new User
                        {
                            UserID = (int) dataReader["UserID"],
                            FirstName = dataReader["Firstname"].ToString(),
                            LastName = dataReader["Lastname"].ToString(),
                            PpPath = dataReader["User_photo_Path"].ToString()
                        };

                        Friend friend = new Friend
                        {
                            FriendEntity = friendEntity,
                            ActionId = (int) dataReader["Action_User_ID"],
                            Status = Friend.eStatus.Accept
                        };

                        if ((int) dataReader["User_One_ID"] == userId)
                        {
                            friend.UserId = (int) dataReader["User_One_ID"];
                        }
                        else
                        {
                            friend.UserId = (int) dataReader["User_Two_ID"];
                        }

                        pendingFriends.Add(friend);
                    }

                    return pendingFriends;
                }
                catch (Exception exception)
                {
                    throw new Exception();
                }
            }
        }

        public List<Friend> GetSearchResult(string searchObject)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand("dbo.GetSearchResult", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@SearchValue", searchObject);
                try
                {
                    connection.Open();

                    SqlDataReader dataReader = command.ExecuteReader();

                    List<Friend> friends = new List<Friend>();

                    while (dataReader.Read())
                    {
                        User SearchEntity = new User
                        {
                            UserID = (int)dataReader["UserID"],
                            FirstName = dataReader["Firstname"].ToString(),
                            LastName = dataReader["Lastname"].ToString(),
                            PpPath = dataReader["User_photo_Path"].ToString()
                        };

                        Friend Searchfriend = new Friend
                        {
                            FriendEntity = SearchEntity,
                            ActionId = (int)dataReader["Action_User_ID"],
                        };

//                        if ((int)dataReader["User_One_ID"] == userId)
//                        {
//                            Searchfriend.UserId = (int)dataReader["User_One_ID"];
//                        }
//                        else
//                        {
//                            Searchfriend.UserId = (int)dataReader["User_Two_ID"];
//                        }

                        
                        switch(dataReader["status"])
                        {
                            case "Accept" :
                                Searchfriend.Status = Friend.eStatus.Accept;
                                break;
                            case "Pending" :
                                Searchfriend.Status = Friend.eStatus.Pending;
                                break;
                            case "Blocked" :
                                Searchfriend.Status = Friend.eStatus.Blocked;
                                break;
                        }

                        friends.Add(Searchfriend);
                    }

                    return friends;
                }
                catch (Exception errorException)
                {
                    throw errorException;
                }
            }
        }
    }
}