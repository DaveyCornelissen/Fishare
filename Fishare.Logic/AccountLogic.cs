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

        /// <summary>
        /// The account constructor with a config parameter who checks which context is used.
        /// </summary>
        /// <param name="config"></param>
        public AccountLogic(IConfiguration config)
        {
            ContextReader contextReader = new ContextReader(config);

            switch (contextReader.Context)
            {
                case "MSSQL":
                    _context = new AccountSQLContext(contextReader.ConnectionString);
                    break;
                default:
                    _context = new AccountMemoryContext();
                    break;
            }

            _repository = new AccountRepository(_context);
        }

        /// <summary>
        /// Check if The login parameters a valid and if the user exist with the parameters
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        public void CheckLogin(string email, string password)
        {
            if (String.IsNullOrEmpty(email) || String.IsNullOrEmpty(password))
                throw new ExceptionHandler("ErrorNullableParameters", "Email or password parameter is null or empty");

            if (!_repository.CheckLogin(email, password))
                throw new ExceptionHandler("ErrorNoUser", "Email or password does not exist! Please try again");
        }

        /// <summary>
        /// Get the right info to create cookies
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public User GetCookieInfo(string email)
        {
            if (String.IsNullOrEmpty(email))
                throw new ExceptionHandler("ErrorNullableParameters", "Email parameter is null or empty");

            User userResult = _repository.GetCookieInfo(email);

            if (userResult == null)
                throw new ExceptionHandler("ErrorNoCookiesInfo", "Oops something went wrong! we couldn't reach the CookieBox");

            return userResult;
        }

        /// <summary>
        /// Create the user with the new user entity and run some checks
        /// </summary>
        /// <param name="entity"></param>
        public void CreateUser(User entity)
        {
            if (String.IsNullOrEmpty(entity.UserEmail) || String.IsNullOrEmpty(entity.Password) || String.IsNullOrEmpty(entity.FirstName) || String.IsNullOrEmpty(entity.LastName))
                throw new ExceptionHandler("ErrorNullableParameters", "Required parameter is null or empty");

            if (_repository.Exist(entity.UserEmail))
                throw new ExceptionHandler("ErrorEmailExist", "The email already exist! Please choose another one.");

            string password = entity.Password;

            if (!(password.Any(char.IsUpper) && password.Any(char.IsDigit) && password.Length >= 8 && !String.IsNullOrWhiteSpace(password)))
                throw new ExceptionHandler("ErrorPassword", "The password does not match the requirements!");

            if (!_repository.Create(entity))
                throw new ExceptionHandler("UserCreateFailed", "Oops something went wrong! your account has failed to create!");
        }

        /// <summary>
        /// Get the User with the id
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public User GetUserProfile(int UserId)
        {
            if (UserId == 0)
                throw new ExceptionHandler("ErrorNullableParameters", "UserId parameter is null or empty");

            return _repository.Read(UserId);
        } 

        /// <summary>
        /// Update the user entity and checks if the required parameters are valid.
        /// </summary>
        /// <param name="entity"></param>
        public void UpdateUser(User entity)
        {
            if (String.IsNullOrEmpty(entity.UserEmail) || String.IsNullOrEmpty(entity.FirstName) || String.IsNullOrEmpty(entity.LastName))
                throw new ExceptionHandler("ErrorNullableParameters", "Required parameter is null or empty");

            User _oldUser = _repository.Read(entity.UserId);

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
                if (!(password.Any(char.IsUpper) && password.Any(char.IsDigit) && password.Length >= 8 && !String.IsNullOrWhiteSpace(password)))
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
