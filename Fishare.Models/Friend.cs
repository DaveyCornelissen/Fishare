using System;
using System.Collections.Generic;
using System.Text;

namespace Fishare.Models
{
    class Friend
    {
        public User User { get; private set; }
        public User Frienduser { get; private set; }
        public eStatus Status { get; private set; }

        public Friend(User user, User friend, eStatus status)
        {
            this.User = User;
            this.Frienduser = friend;
            this.Status = status;

        }

        public enum eStatus
        {
            Pending,
            Blocked,
            Accept
        }

        public void AcceptFriend()
        {

        }

        public void BlockFriend()
        {

        }

        public void DeleteFriend()
        {

        }
    }
}
