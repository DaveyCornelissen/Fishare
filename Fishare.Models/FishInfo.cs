using System;
using System.Collections.Generic;
using System.Text;

namespace Fishare.Model
{
    public class FishInfo
    {
        /// <summary>
        /// Gets the fish info id.
        /// </summary>
        public int FishInfoID { get; private set; }

        /// <summary>
        /// Gets the fish.
        /// </summary>
        public Fish Fish { get; private set; }

        /// <summary>
        /// Gets the weight.
        /// </summary>
        public double Weight { get; private set; }

        /// <summary>
        /// Gets the lenght.
        /// </summary>
        public double Lenght { get; private set; }

        /// <summary>
        /// Gets the bait.
        /// </summary>
        public string Bait { get; private set; }
    }
}
