using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Fishare.Model;
using Fishare.Repository.Interface;

namespace Fishare.DAL.SQL
{
    public class PostSQLContext : IPostRepository
    {
        private readonly string connectionString;

        public PostSQLContext(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public bool Create(Post entity)
        {
            throw new NotImplementedException();
        }

        public Post Read(int Id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Post entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete()
        {
            throw new NotImplementedException();
        }

        public List<Post> GetPosts(List<int> ids)
        {
            //initialize the list for all the posts
            List<Post> Posts = new List<Post>();

            foreach (int id in ids)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand("dbo.GetAllPosts", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UserId", id);
                    try
                    {
                        connection.Open();

                        SqlDataReader dataReader = command.ExecuteReader();

                        while (dataReader.Read())
                        {
                            Post Userpost = new Post
                            {
                                PostID = (int) dataReader["PostID"],
                                UserId = (int) dataReader["UserID"],
                                Title = (string) dataReader["Title"],
                                Description = (string) dataReader["Description"],
                                DateTime = (DateTime) dataReader["DateTime"],
                                Location = (string) dataReader["Location"],
                                PublicPost = Convert.ToBoolean((int) dataReader["Public"]),
                                PostLike = (int) dataReader["TotalLikes"],
                                UserProfileImage = (string)dataReader["User_photo_Path"] ?? string.Empty,
                                UserName = (string)dataReader["Firstname"] + (string)dataReader["Lastname"]
                            };

                            if ((int) dataReader["FishInfo_FishInfoID"] != 0)
                            {
                                FishInfo fishInfo = new FishInfo
                                {
                                    FishInfoID = (int) dataReader["FishInfo_FishInfoID"],
                                    Name = (string) dataReader["Name"] ?? string.Empty,
                                    Lenght = Convert.ToDouble((decimal) dataReader["Lenght"] == null
                                        ? 0
                                        : (decimal) dataReader["Lenght"]),
                                    Weight = Convert.ToDouble((decimal) dataReader["Weight"] == null
                                        ? 0
                                        : (decimal) dataReader["Weight"]),
                                    Bait = (string) dataReader["Bait"] ?? string.Empty,
                                };

                                Userpost.FishInfo = fishInfo;
                            }

                            Posts.Add(Userpost);
                        }

                        List<PPhoto> postPictureList = new List<PPhoto>();

                        //for the next table
                        if (dataReader.NextResult())
                        {
                            while (dataReader.Read())
                            {
                                PPhoto postPhoto = new PPhoto
                                {
                                    Post = (int) dataReader["Post_PostID"],
                                    Path = (string) dataReader["Path"] ?? string.Empty
                                };

                                postPictureList.Add(postPhoto);
                            }
                        }

                        foreach (PPhoto Photo in postPictureList)
                        {
                            Post post = Posts.Find(P => P.PostID == Photo.Post);

                            if (post.Photos == null)
                                post.Photos = new List<PPhoto>();

                            if (post != null)
                            {
                                PPhoto _tempList = new PPhoto
                                {
                                    Post = Photo.Post,
                                    Path = Photo.Path
                                };

                                post.Photos.Add(_tempList);
                            }
                        }
                    }
                    catch (Exception errorException)
                    {
                        throw errorException;
                    }


                    
                }
            }

            return Posts;
        }
    }
}
