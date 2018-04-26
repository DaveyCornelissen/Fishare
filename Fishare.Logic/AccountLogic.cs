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

        //Check if the user email and password exist
        public bool CheckLogin(string email, string password) => _repository.CheckLogin(email, password);

        //Getting user-id and user-name
        public User GetCookieInfo(string email) => _repository.GetCookieInfo(email);

        //Check if the email already exist
        public bool CheckExist(string email) => _repository.Exist(email);

        //Create the new user
        public bool CreateUser(User entity)
        {
            bool emailExist = CheckExist(entity.UserEmail);

            if (emailExist)
            {
                throw new ExceptionHandler("ErrorEmailExist","The email already exist! Please choose another one.");
            }

            string password = entity.Password;

            if (password.Any(char.IsUpper) && password.Any(char.IsDigit) && password.Length >= 8 && password.Any(char.IsSymbol))
            {
                throw new ExceptionHandler("ErrorPassword", "The password does not match the requirements!");
            }

            return _repository.create(entity);
        }

        public User GetUserProfile(int UserId) => _repository.Read(UserId);

    }
}
