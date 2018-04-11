using System;
using Fishare.DAL.Interface;
using Fishare.Repository.Interface;
using Fishare.ViewModels;

namespace Fishare.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private IAccountContext Context { get; }

        public AccountRepository(IAccountContext context)
        {
            this.Context = context;
        }

        public bool create()
        {
            throw new NotImplementedException();
        }

        public bool Delete()
        {
            throw new NotImplementedException();
        }

        public bool Exist(LoginViewModel model)
        {
            return this.Context.Exist(model);
        }

        public bool Read()
        {
            throw new NotImplementedException();
        }

        public bool Update()
        {
            throw new NotImplementedException();
        }
    }
}
