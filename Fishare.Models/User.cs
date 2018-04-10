using System;
using System.Collections.Generic;
using System.Text;

namespace Fishare.Models
{
    class User
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDay { get; set; }
        public string PhoneNumber { get; set; }
        public string Bio { get; set; }
        public string PPPath { get; set; }
        public List<Post> Posts { get; set; }
        public List<Friend> Friends { get; set; }

        public User()
        {
            
        }

        public void ChangeUser()
        {

        }

        public void UploadPPhoto()
        {

        }

        public void ChangePassword()
        {

        }

        public void deleteUser()
        {

        }
    }
}
