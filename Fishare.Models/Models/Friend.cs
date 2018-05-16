using System;
using System.Collections.Generic;
using System.Text;

namespace Fishare.Model
{
    public class Friend
    {
        public int UserId { get; set; }

        public User FriendEntity { get; set; }

        public eStatus Status { get; set; }

        public int ActionId { get; set; }

        public enum eStatus
        {
            Pending,
            Blocked,
            Accept
        }

    }
}
