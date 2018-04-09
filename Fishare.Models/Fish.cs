using System;
using System.Collections.Generic;
using System.Text;

namespace Fishare.Models
{
    class Fish
    {
        public int FishID { get; set; }
        public string FishName { get; set; }
        public string FishDescription { get; set; }
        public string SubSpecies { get; set; }
        public string NameInLatin { get; set; }
        public string Food { get; set; }
        public double AverageLenght { get; set; }
        public double AverageWeight { get; set; }
        public WType WaterType { get; set; }
        public AType AnimalType { get; set; }
        public string FPPath { get; set; }

        public Fish()
        {
            
        }

        public enum WType
        {
            FreshWater,
            SaltWater
        }

        public enum AType
        {
            Omnivore,
            Carnivore,
            Herbivore
        }
        
    }
}
