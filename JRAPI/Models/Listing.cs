using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JRAPI.Models
{
    public class Listing
    {
        public string name { get; set; }
        public double pricePerPassenger { get; set; }
        public VehicleType vehicleType { get; set; }
    }
}
