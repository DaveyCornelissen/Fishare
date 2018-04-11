using System;
using System.Collections.Generic;
using System.Text;
using Fishare.Model;
using Fishare.ViewModels;

namespace Fishare.DAL.Interface
{
     public interface IAccountContext : IContext
    {
        bool Exist(LoginViewModel Entity);

        User GetUserInfo(LoginViewModel Entity);
    }
}
