using System;
using System.Collections.Generic;
using System.Text;
using Fishare.Model;
using Fishare.Repository.Interface;

namespace Fishare.DAL.Memory
{
    public class PostMemoryContext : IRepository<Post>
    {
        List<Post> AllPosts = new List<Post>();

        public PostMemoryContext()
        {
            AllPosts.Add(new Post
            {
                PostID = 1,
                UserId = 1,
                Title = "test",
                DateTime = DateTime.Now
                
            });
            AllPosts.Add(new Post
            {
                PostID = 2,
                UserId = 1,
                Title = "test2",
                DateTime = DateTime.Now

            });
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
    } 
}
