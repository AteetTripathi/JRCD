using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JRAPI.Models
{
    public class Quote
    {
        public string from { get; set; }
        public string to { get; set; }
        public List<Listing> listings { get; set; }
    }
}
