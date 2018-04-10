using System;
using System.Collections.Generic;
using System.Text;

namespace Fishare.Model
{
    public class Post
    {

        /// <summary>
        /// Gets or sets the post id.
        /// </summary>
        public int PostID { get; set; }

        /// <summary>
        /// Gets or sets the photos.
        /// </summary>
        public List<PPhoto> Photos { get; set; }

        /// <summary>
        /// Gets or sets the user.
        /// </summary>
        public User User { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the date time.
        /// </summary>
        public DateTime DateTime { get; set; }

        /// <summary>
        /// Gets or sets the location.
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether public post.
        /// </summary>
        public bool PublicPost { get; set; }

        /// <summary>
        /// Gets or sets the post like.
        /// </summary>
        public int PostLike { get; set; }

        /// <summary>
        /// Gets or sets the reactions.
        /// </summary>
        public List<PReaction> Reactions { get; set; }

        /// <summary>
        /// Gets or sets the fish info.
        /// </summary>
        public FishInfo FishInfo { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Post"/> class.
        /// </summary>
        /// <param name="postID">
        /// The post id.
        /// </param>
        /// <param name="photos">
        /// The photos.
        /// </param>
        /// <param name="user">
        /// The user.
        /// </param>
        /// <param name="title">
        /// The title.
        /// </param>
        /// <param name="description">
        /// The description.
        /// </param>
        /// <param name="dateTime">
        /// The date time.
        /// </param>
        /// <param name="location">
        /// The location.
        /// </param>
        /// <param name="publicPost">
        /// The public post.
        /// </param>
        /// <param name="postLike">
        /// The post like.
        /// </param>
        /// <param name="reactions">
        /// The reactions.
        /// </param>
        /// <param name="fishInfo">
        /// The fish info.
        /// </param>
        public Post(int postID, List<PPhoto> photos, User user, string title, string description, DateTime dateTime, string location, bool publicPost, int postLike, List<PReaction> reactions, FishInfo fishInfo)
        {
            this.PostID = postID;
            this.Photos = photos;
            this.User = user;
            this.Title = title;
            this.Description = description;
            this.DateTime = dateTime;
            this.Location = location;
            this.PublicPost = publicPost;
            this.PostLike = postLike;
            this.Reactions = reactions;
            this.FishInfo = fishInfo;
        }

    }
}
