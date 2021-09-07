using JRAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JRAPI.DTO
{
    public class QuoteDto
    {

        public string from { get; set; }
        public string to { get; set; }
        public List<ListingDto> listings { get; set; }
    }
}
