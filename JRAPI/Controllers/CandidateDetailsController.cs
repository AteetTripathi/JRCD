using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JRAPI.Models;

namespace JRAPI.Controllers
{
    [Route("api/cadidatedb")]
    [ApiController]
    public class CandidateDetailsController : ControllerBase
    {
        private readonly CandidateContext _context;

        public CandidateDetailsController(CandidateContext context)
        {
            _context = context;
        }

        // GET: api/CandidateDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CandidateDetail>>> GetCandidateDetails()
        {
            return await _context.CandidateDetails.ToListAsync();
        }

        // GET: api/CandidateDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CandidateDetail>> GetCandidateDetail(long id)
        {
            var candidateDetail = await _context.CandidateDetails.FindAsync(id);

            if (candidateDetail == null)
            {
                return NotFound();
            }

            return candidateDetail;
        }

        // PUT: api/CandidateDetails/5
        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCandidateDetail(long id, CandidateDetail candidateDetail)
        {
            if (id != candidateDetail.Id)
            {
                return BadRequest();
            }

            _context.Entry(candidateDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CandidateDetailExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/CandidateDetails
        [HttpPost]
        public async Task<ActionResult<CandidateDetail>> PostCandidateDetail(CandidateDetail candidateDetail)
        {
            _context.CandidateDetails.Add(candidateDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCandidateDetail), new { id = candidateDetail.Id }, candidateDetail);
            
        }

        // DELETE: api/CandidateDetails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CandidateDetail>> DeleteCandidateDetail(long id)
        {
            var candidateDetail = await _context.CandidateDetails.FindAsync(id);
            if (candidateDetail == null)
            {
                return NotFound();
            }

            _context.CandidateDetails.Remove(candidateDetail);
            await _context.SaveChangesAsync();

            return candidateDetail;
        }

        private bool CandidateDetailExists(long id)
        {
            return _context.CandidateDetails.Any(e => e.Id == id);
        }
    }
}
