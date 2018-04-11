using System;
using System.Collections.Generic;
using System.Text;

namespace Fishare.Model
{
    public class PReaction
    {
        public Post Post { get; private set; }

        public User User { get; private set; }

        public string Reaction { get; private set; }

        public DateTime DateTime { get; private set; }
    }
}
