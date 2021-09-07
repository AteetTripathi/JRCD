using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JRAPI.Models
{
    public class CandidateDetail
    {
        [JsonIgnore]
        public long Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
    }
}
