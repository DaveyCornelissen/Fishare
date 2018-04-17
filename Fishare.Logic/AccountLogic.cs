using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fishare.DAL;
using Fishare.DAL.Memory;
using Fishare.DAL.SQL;
using Fishare.Model;
using Fishare.ViewModels;
using Fishare.Repository;
using Fishare.Repository.Interface;
using Microsoft.Extensions.Configuration;


namespace Fishare.Logic
{
    public class AccountLogic
    {
        private IAccountRepository _repository;

        private IAccountRepository _context;

        public AccountLogic(IConfiguration config)
        {
            ContextReader contextReader = new ContextReader(config);

            switch (contextReader.Context)
            {
                case "MSSQL":
                    _context = new AccountSQLContext(contextReader.ConnectionString);
                    break;
                case "MEMORY":
                    _context = new AccountMemoryContext();
                    break;
                default: throw new NotImplementedException();
            }

            _repository = new AccountRepository(_context);
        }
       
        public bool CheckLogin(LoginViewModel entity) => _repository.CheckLogin(entity.Email, entity.Password);

        public User GetUser(string email) => _repository.Read(email);

        public bool CheckExist(string email) => _repository.Exist(email);

        public bool CreateUser(User entity) => _repository.create(entity);

    }
}
