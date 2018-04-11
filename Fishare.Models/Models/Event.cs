using System;
using System.Collections.Generic;
using System.Text;

namespace Fishare.Model
{
    class Event
    {
        public int EventID { get; private set; }

        public List<EPhoto> Photos { get; private set; }

        public string EventName { get; private set; }

        public User EOwner { get; private set; }

        public DateTime DateTime { get; private set; }

        public string Location { get; private set; }

        public string Type { get; private set; }

        public eRange Range { get; private set; }

        public string Description { get; private set; }

        public string Condition { get; private set; }

        public int MaxUsers { get; private set; }

        public List<EJoined> UsersList { get; private set; }


        public Event()
        {
            
        }

        public enum eRange
        {
            FishClub,
            Friends,
            Public
        }
    }
}
