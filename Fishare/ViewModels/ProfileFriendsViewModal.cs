using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fishare.Model;

namespace Fishare.ViewModels
{
    public class ProfileFriendsViewModal
    {
        public Friend Friend { get; set; }

        public string SearchFriendsBox { get; set; }

        public List<Friend> AcceptedFriends { get; set; }

        public List<Friend> PendingFriends { get; set; }

        public List<Friend> BlockedFriends { get; set; }

        public List<Friend> SearchedFriends { get; set; }


    }
}
