using System;
using System.Collections.Generic;
using System.Text;

namespace Fishare.Model
{
    public class Friend
    {
        /// <summary>
        /// Gets the user.
        /// </summary>
        public User User { get; private set; }

        /// <summary>
        /// Gets the frienduser.
        /// </summary>
        public User Frienduser { get; private set; }

        /// <summary>
        /// Gets the status.
        /// </summary>
        public eStatus Status { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Friend"/> class.
        /// </summary>
        /// <param name="user">
        /// The user.
        /// </param>
        /// <param name="friend">
        /// The friend.
        /// </param>
        /// <param name="status">
        /// The status.
        /// </param>
        public Friend(User user, User friend, eStatus status)
        {
            this.User = User;
            this.Frienduser = friend;
            this.Status = status;

        }

        /// <summary>
        /// The e status.
        /// </summary>
        public enum eStatus
        {
            Pending,
            Blocked,
            Accept
        }

    }
}
