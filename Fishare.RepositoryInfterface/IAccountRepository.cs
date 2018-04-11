using System;
using System.Collections.Generic;
using System.Text;
using Fishare.ViewModels;

namespace Fishare.Repository.Interface
{
    public interface IAccountRepository : IRepository
    {
        bool Exist(LoginViewModel model);
    }
}
