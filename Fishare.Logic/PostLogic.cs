using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fishare.DAL;
using Fishare.DAL.Memory;
using Fishare.DAL.SQL;
using Fishare.Model;
using Fishare.Repository;
using Fishare.Repository.Interface;
using Microsoft.Extensions.Configuration;

namespace Fishare.Logic
{
    public class PostLogic
    {
        private IPostRepository _repository;

        private IPostRepository _context;

        public PostLogic(IConfiguration config)
        {
            ContextReader contextReader = new ContextReader(config);

            switch (contextReader.Context)
            {
                case "MSSQL":
                    _context = new PostSQLContext(contextReader.ConnectionString);
                    break;
                case "MEMORY":
                    _context = new PostMemoryContext();
                    break;
                default: throw new NotImplementedException();
            }

            _repository = new PostRepository(_context);
        }

        public List<Post> GetPosts(List<int> ids)
        {
            List<Post> postsList = _repository.GetPosts(ids);

           // postsList.OrderBy(o => o.DateTime).ToList();

            return postsList;
        } 
    }
}
