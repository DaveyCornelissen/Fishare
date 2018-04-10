using System;
using System.Collections.Generic;
using System.Text;

namespace Fishare.Model
{
    /// <summary>
    /// The post reaction.
    /// </summary>
    public class PReaction
    {
        /// <summary>
        /// Gets the post.
        /// </summary>
        public Post Post { get; private set; }

        /// <summary>
        /// Gets the user.
        /// </summary>
        public User User { get; private set; }

        /// <summary>
        /// Gets the reaction.
        /// </summary>
        public string Reaction { get; private set; }

        /// <summary>
        /// Gets the date time.
        /// </summary>
        public DateTime DateTime { get; private set; }
    }
}
