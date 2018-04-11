using System;
using System.Collections.Generic;
using System.Text;

namespace Fishare.Model
{
    public class Post
    {
        public int PostID { get; set; }

        public List<PPhoto> Photos { get; set; }

        public User User { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime DateTime { get; set; }

        public string Location { get; set; }

        public bool PublicPost { get; set; }

        public int PostLike { get; set; }

        public List<PReaction> Reactions { get; set; }

        public FishInfo FishInfo { get; set; }

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
