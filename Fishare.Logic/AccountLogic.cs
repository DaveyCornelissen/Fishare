using System;
using System.Collections.Generic;
using System.Text;
using Fishare.DAL;


namespace Fishare.Logic
{
    using Fishare.DAL.Memory;
    using Fishare.Model;

    public class AccountLogic
    {
        AccountMemoryContext Repo = new AccountMemoryContext();

        public User checkLogin(User account) => this.Repo.CheckUserExist(account);
    }
}
