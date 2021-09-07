using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JRAPI.Models;

namespace JRAPI.DTO
{
    public class ListingDto
    {
        public string name { get; set; }
        public double pricePerPassenger { get; set; }
        public double totalPrice { get; set; }
        public VehicleType vehicleType { get; set; }
    }
}
