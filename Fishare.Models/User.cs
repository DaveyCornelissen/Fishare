using System;
using System.Collections.Generic;
using System.Text;

namespace Fishare.Model
{
    /// <summary>
    /// The user.
    /// </summary>
    public class User
    {
        /// <summary>
        /// Gets or sets the user id.
        /// </summary>
        public int UserID { get; set; }

        /// <summary>
        /// Gets or sets the user name.
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets the user email.
        /// </summary>
        public string UserEmail { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the birth day.
        /// </summary>
        public DateTime BirthDay { get; set; }

        /// <summary>
        /// Gets or sets the phone number.
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets the bio.
        /// </summary>
        public string Bio { get; set; }

        /// <summary>
        /// Gets or sets the pp path.
        /// </summary>
        public string PpPath { get; set; }

        /// <summary>
        /// Gets or sets the posts.
        /// </summary>
        public List<Post> Posts { get; set; }

        /// <summary>
        /// Gets or sets the friends.
        /// </summary>
        public List<Friend> Friends { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="User"/> class.
        /// </summary>
        /// <param name="userID">
        /// The user id.
        /// </param>
        /// <param name="userName">
        /// The user name.
        /// </param>
        /// <param name="userEmail">
        /// The user email.
        /// </param>
        /// <param name="password">
        /// The password.
        /// </param>
        /// <param name="firstName">
        /// The first name.
        /// </param>
        /// <param name="lastName">
        /// The last name.
        /// </param>
        /// <param name="birthDay">
        /// The birth day.
        /// </param>
        /// <param name="phoneNumber">
        /// The phone number.
        /// </param>
        /// <param name="bio">
        /// The bio.
        /// </param>
        /// <param name="pPPath">
        /// The p p path.
        /// </param>
        public User(int userID, string userName, string userEmail, string password, string firstName, string lastName, DateTime birthDay, string phoneNumber, string bio, string pPPath)
        {
            this.UserID = userID;
            this.UserName = userName;
            this.UserEmail = userEmail;
            this.Password = password;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.BirthDay = birthDay;
            this.PhoneNumber = phoneNumber;
            this.Bio = bio;
            this.PpPath = pPPath;
        }

        public User()
        {
            
        }
    }
}
