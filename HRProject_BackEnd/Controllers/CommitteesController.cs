using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HRProject_BackEnd.Models;
using HRProject_BackEnd.Presistence;

namespace HRProject_BackEnd.Controllers
{
    [Route("api/Committees")]
    [ApiController]
    public class CommitteesController : ControllerBase
    {
        private readonly CommitteeDBContext _context;

        public CommitteesController(CommitteeDBContext context)
        {
            _context = context;
        }

        // GET: api/Committees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Committees>>> GetCommittees()
        {
            return await _context.Committees.ToListAsync();
        }

        // GET: api/Committees/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Committees>> GetCommittees(int id)
        {
            var committees = await _context.Committees.FindAsync(id);

            if (committees == null)
            {
                return NotFound();
            }

            return committees;
        }

        // PUT: api/Committees/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCommittees(int id, Committees committees)
        {
            if (id != committees.CommitteeID)
            {
                return BadRequest();
            }

            _context.Entry(committees).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommitteesExists(id))
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

        // POST: api/Committees
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Committees>> PostCommittees(Committees committees)
        {
            _context.Committees.Add(committees);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCommittees", new { id = committees.CommitteeID }, committees);
        }

        // DELETE: api/Committees/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCommittees(int id)
        {
            var committees = await _context.Committees.FindAsync(id);
            if (committees == null)
            {
                return NotFound();
            }

            _context.Committees.Remove(committees);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CommitteesExists(int id)
        {
            return _context.Committees.Any(e => e.CommitteeID == id);
        }
    }
}
