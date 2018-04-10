using System;
using System.Collections.Generic;
using System.Text;
using Fishare.Model;

namespace Fishare.DAL.Memory
{
    public class AccountMemoryContext
    {
        List<User> AllUsers = new List<User>();

        public AccountMemoryContext()
        {
            this.AllUsers.Add(new User(1,"Davey21","d.cornelissen8@gmail.com","1234","Davey","Cornelssen",DateTime.Today, "0628433115","Ïm a fisher", "/test/profielpicture.png"));
        }

        public User CheckUserExist(User LGUser)
        {
            User user = this.AllUsers.Find(u => u.UserEmail == LGUser.UserEmail && u.Password == LGUser.Password);

            return user;
        }
    }
}
