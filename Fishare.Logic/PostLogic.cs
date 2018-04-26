using System;
using System.Collections.Generic;
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
        private IRepository<Post> _repository;

        private IRepository<Post> _context;

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

            _repository = new Repository<Post>(_context);
        }

//        public List<Post> GetPosts()
//        {
//
//        }
    }
}
