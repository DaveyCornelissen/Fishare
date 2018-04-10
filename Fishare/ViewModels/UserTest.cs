using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fishare.ViewModels
{
    using Fishare.Model;

    public class UserTest
    {
        public UserTest(User user)
        {
            User = user;
        }

        public UserTest()
        {
            
        }
        public User User { get; set; }

        
    }
}
