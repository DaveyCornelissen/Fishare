using System;
using System.Collections.Generic;
using System.Text;
using Fishare.Model;
using Fishare.Repository.Interface;

namespace Fishare.DAL.SQL
{
    public class PostSQLContext : IRepository<Post>
    {
        private readonly string _connectionString;

        public PostSQLContext(string connectionString)
        {
            this._connectionString = connectionString;
        }

        public bool create(Post entity)
        {
            throw new NotImplementedException();
        }

        public Post Read(int Id)
        {
            throw new NotImplementedException();
        }

        public bool Update()
        {
            throw new NotImplementedException();
        }

        public bool Delete()
        {
            throw new NotImplementedException();
        }
    }
}
