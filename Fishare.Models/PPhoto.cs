using System;
using System.Collections.Generic;
using System.Text;

namespace Fishare.Model
{
    /// <summary>
    /// The posts photo.
    /// </summary>
    public class PPhoto
    {
        /// <summary>
        /// Gets the post.
        /// </summary>
        public Post Post { get; private set; }

        /// <summary>
        /// Gets the path.
        /// </summary>
        public string Path { get; private set; }
    }
}
