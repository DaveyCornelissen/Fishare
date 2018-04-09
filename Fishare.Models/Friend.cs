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

        public Friend()
        {
            
        }

        public enum eStatus
        {
            Pending,
            Blocked,
            Accept
        }
    }
}
