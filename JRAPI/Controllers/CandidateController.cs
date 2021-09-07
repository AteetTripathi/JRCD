using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using JRAPI.Models;

namespace JRAPI.Controllers
{
    [Route("api/candidate")]
    [ApiController]
    public class CandidateController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<CandidateDetail> Get()
        {
            List<CandidateDetail> candidates = new List<CandidateDetail>();
            candidates.Add(new CandidateDetail()
            {
                Id = 1,
                Name = "test",
                Phone = "test"
            });
            return candidates;
        }
    }
}
