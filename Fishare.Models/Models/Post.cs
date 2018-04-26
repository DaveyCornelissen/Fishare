using System;
using System.Collections.Generic;
using System.Text;

namespace Fishare.Model
{
    public class Post
    {
        public int PostID { get; set; }

        public string PrimaryPhoto { get; set; }

        public List<PPhoto> Photos { get; set; }

        public int UserId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime DateTime { get; set; }

        public string Location { get; set; }

        public bool PublicPost { get; set; }

        public int PostLike { get; set; }

        public List<PReaction> Reactions { get; set; }

        public FishInfo FishInfo { get; set; }

    }
}
