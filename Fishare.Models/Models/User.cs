using System;
using System.Collections.Generic;
using System.Text;

namespace Fishare.Model
{
    public class User
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

        public string PpPath { get; set; }

        public List<Post> Posts { get; set; }

        public List<Friend> Friends { get; set; }

        public User(int userID, string userName, string userEmail, string password, string firstName, string lastName, DateTime birthDay, string phoneNumber, string bio, string pPPath)
        {
            this.UserID = userID;
            this.UserName = userName;
            this.UserEmail = userEmail;
            this.Password = password;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.BirthDay = birthDay;
            this.PhoneNumber = phoneNumber;
            this.Bio = bio;
            this.PpPath = pPPath;
        }
    }
}
