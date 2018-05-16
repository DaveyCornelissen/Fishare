using System;
using System.Collections.Generic;
using Fishare.Model;

namespace Fishare.ViewModels
{
    public class ProfileInfoViewModel
    {
        public string PhoneNumber { get; set; }

        public string PPath { get; set; }

        public DateTime Birthday { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Bio { get; set; }

        public List<Post> Posts { get; set; }

        public int TotalFriends { get; set; }

        //public List<Friend> Friends { get; set; }
    }
}
