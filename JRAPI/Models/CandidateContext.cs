using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace JRAPI.Models
{
    public class CandidateContext:DbContext
    {
        public CandidateContext(DbContextOptions<CandidateContext> options)
            :base(options)
        {

        }

        public DbSet<CandidateDetail> CandidateDetails { get; set; }
    }
}
