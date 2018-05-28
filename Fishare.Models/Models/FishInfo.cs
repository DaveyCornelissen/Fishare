using System;
using System.Collections.Generic;
using System.Text;

namespace Fishare.Model
{
    public class FishInfo
    {
        public int FishInfoID { get; set; }

        public Fish Fish { get; set; }

        public string Name { get; set; }

        public double Weight { get; set; }

        public double Lenght { get; set; }

        public string Bait { get; set; }
    }
}
