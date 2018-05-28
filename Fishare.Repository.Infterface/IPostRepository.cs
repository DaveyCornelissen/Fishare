using System;
using System.Collections.Generic;
using System.Text;
using Fishare.Model;

namespace Fishare.Repository.Interface
{
    public interface IPostRepository : IRepository<Post>
    {
        List<Post> GetPosts(List<int> ids);
    }
}
