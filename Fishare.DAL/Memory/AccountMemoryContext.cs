using System;
using System.Collections.Generic;
using System.Text;
using Fishare.Model;
using Fishare.ViewModels;
using Fishare.DAL.Interface;

namespace Fishare.DAL.Memory
{
    public class AccountMemoryContext : IAccountContext
    {
        List<User> AllUsers = new List<User>();

        public AccountMemoryContext()
        {
            this.AllUsers.Add(new User(1,"Davey21","d.cornelissen8@gmail.com","1234","Davey","Cornelssen",DateTime.Today, "0628433115","Ïm a fisher", "/test/profielpicture.png"));
        }

        public User GetUserInfo(LoginViewModel Entity)
        {
            User user = this.AllUsers.Find(u => u.UserEmail == Entity.Email && u.Password == Entity.Password);

            return user;
        }

        public bool create()
        {
            throw new NotImplementedException();
        }

        public bool Delete()
        {
            throw new NotImplementedException();
        }

        public bool Exist(LoginViewModel Entity)
        {
            User user = this.AllUsers.Find(u => u.UserEmail == Entity.Email && u.Password == Entity.Password);

            return user != null;
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
