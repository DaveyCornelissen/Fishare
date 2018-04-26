using System;
using System.Collections.Generic;
using System.Text;
using Fishare.Model;
using Fishare.Repository.Interface;
using Microsoft.Extensions.Configuration;

namespace Fishare.Repository
{
    public class PostRepository : Repository<Post>, IPostRepository
    {
        private new IPostRepository _context;

        public PostRepository(IPostRepository context) : base(context)
        {
            _context = context;
        }
    }
}
