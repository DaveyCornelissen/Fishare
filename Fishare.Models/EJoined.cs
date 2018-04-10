using System;
using System.Collections.Generic;
using System.Text;

namespace Fishare.Model
{
    class EJoined
    {
        public Event Event { get; private set; }
        public User User { get; private set; }
        public eStatus Status { get; private set; }

        public EJoined()
        {
            
        }

        public enum eStatus
        {
            Accept,
            Pending
        }
    }
}
