using System;
using System.Collections.Generic;
using System.Text;

namespace Fishare.Model
{
    public class FishInfo
    {
        public int FishInfoID { get; private set; }

        public Fish Fish { get; private set; }

        public double Weight { get; private set; }

        public double Lenght { get; private set; }

        public string Bait { get; private set; }
    }
}
