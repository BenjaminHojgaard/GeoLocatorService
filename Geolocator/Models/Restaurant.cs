using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Geolocator.Models
{
    public class Restaurant
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public double Rating { get; set; }
        public int PriceLevel { get; set; }
    }
}
