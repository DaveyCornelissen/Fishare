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
        public void CheckLogin(string email, string password)
        {
            if (!_repository.CheckLogin(email, password))
                throw new ExceptionHandler("ErrorNoUser", "Email or password does not exist! Please try again");
        }

        //Getting user-id and user-name
        public User GetCookieInfo(string email)
        {
            User userResult = _repository.GetCookieInfo(email);

            if (userResult == null)
                throw new ExceptionHandler("ErrorNoCookiesInfo", "Oops something went wrong! we couldn't reach the CookieBox");

            return userResult;
        }

        //Create the new user
        public void CreateUser(User entity)
        {
            if (_repository.Exist(entity.UserEmail))
                throw new ExceptionHandler("ErrorEmailExist", "The email already exist! Please choose another one.");

            string password = entity.Password;

            if (password.Any(char.IsUpper) && password.Any(char.IsDigit) && password.Length >= 8 && password.Any(char.IsSymbol))
                throw new ExceptionHandler("ErrorPassword", "The password does not match the requirements!");

            if (!_repository.Create(entity))
                throw new ExceptionHandler("UserCreateFailed", "Oops something went wrong! your account has failed to create!");
        }

        //get the User Profile information
        public User GetUserProfile(int UserId) => _repository.Read(UserId);

        //Update the Users Settings
        public void UpdateUser(User entity)
        {
            User _oldUser = _repository.Read(entity.UserID);

            if (_oldUser.UserEmail != entity.UserEmail)
            {
                bool emailExist = _repository.Exist(entity.UserEmail);

                if (emailExist)
                {
                    throw new ExceptionHandler("ErrorEmailExist", "The email already exist! Please choose another one.");
                }
            }

            string password = entity.Password;

            if (password != null)
            {
                if (password.Any(char.IsUpper) && password.Any(char.IsDigit) && password.Length >= 8 && password.Any(char.IsSymbol))
                    throw new ExceptionHandler("ErrorPassword", "The password does not match the requirements!");
            }
            else
            {
                entity.Password = _oldUser.Password;
            }

            if (!_repository.Update(entity))
                throw new ExceptionHandler("UserUpdateFailed", "Oops something went wrong! your account has failed to Update!");
        }
    }
}
