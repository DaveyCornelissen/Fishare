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

        /// <summary>
        /// The Post constructor with a config parameter who checks which context is used.
        /// </summary>
        /// <param name="config"></param>
        public PostLogic(IConfiguration config)
        {
            ContextReader contextReader = new ContextReader(config);

            switch (contextReader.Context)
            {
                case "MSSQL":
                    _context = new PostSQLContext(contextReader.ConnectionString);
                    break;
                default:
                    _context = new PostMemoryContext();
                    break;
            }

            _repository = new PostRepository(_context);
        }

        /// <summary>
        /// Get all the posts from the friends and the users and orders them by upload date
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public List<Post> GetPosts(List<int> ids)
        {
            List<Post> postsList = _repository.GetPosts(ids);

            postsList.OrderBy(o => o.DateTime).ToList();

            return postsList;
        } 
    }
}
