using System;
using System.Collections.Generic;
using System.Text;
using Fishare.Model;
using Fishare.ViewModels;
using Fishare.DAL;
using Fishare.Repository.Interface;

namespace Fishare.DAL.Memory
{
    public class AccountMemoryContext : IAccountRepository
    {
        List<User> AllUsers = new List<User>();

        public AccountMemoryContext()
        {
            this.AllUsers.Add(new User
                {
                    UserID = 1,
                    UserName = "DaveyCor",
                    UserEmail = "d.cornelissen8@gmail.com",
                    Password = "12345",
                    FirstName = "Davey",
                    LastName = "Cornelissen",
                    BirthDay = DateTime.Now,
                    PhoneNumber = "0628433115",
                    PpPath = "/Test/Profile.PNG"
                });
        }

        public User GetUserInfo(User entity)
        {
            User user = this.AllUsers.Find(u => u.UserEmail == entity.UserEmail && u.Password == entity.Password);

            return user;
        }

        public bool Delete()
        {
            throw new NotImplementedException();
        }

        public bool CheckLogin(string email, string password)
        {
            User user = this.AllUsers.Find(u => u.UserEmail == email && u.Password == password);

            return user != null;
        }

        public bool Exist(string email)
        {
            User user = this.AllUsers.Find(u => u.UserEmail == email);

            return user != null;
        }

        public User Read(string email)
        {
            throw new NotImplementedException();
        }

        public bool Update()
        {
            throw new NotImplementedException();
        }

        public bool create(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
