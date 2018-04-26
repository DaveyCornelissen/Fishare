using System;
using System.Collections.Generic;
using System.Text;
using Fishare.Model;

namespace Fishare.Repository.Interface
{
    public interface IAccountRepository : IRepository<User>
    {
        bool CheckLogin(string email, string password);

        bool Exist(string email);

        User GetCookieInfo(string email);
    }
}
