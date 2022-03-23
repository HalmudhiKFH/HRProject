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
    [Route("api/Meetings")]
    [ApiController]
    public class MeetingsController : ControllerBase
    {
        private readonly CommitteeDBContext _context;

        public MeetingsController(CommitteeDBContext context)
        {
            _context = context;
        }

        // GET: api/Meetings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Meeting>>> GetMeetings()
        {
            return await _context.Meetings.ToListAsync();
        }

        // GET: api/Meetings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Meeting>> GetMeetings(int id)
        {
            var meetings = await _context.Meetings.FindAsync(id);

            if (meetings == null)
            {
                return NotFound();
            }

            return meetings;
        }

        // PUT: api/Meetings/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMeetings(int id, Meeting meetings)
        {
            if (id != meetings.MeetingID)
            {
                return BadRequest();
            }

            _context.Entry(meetings).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MeetingsExists(id))
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

        // POST: api/Meetings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Meeting>> PostMeetings(Meeting meetings)
        {
            _context.Meetings.Add(meetings);
            await _context.SaveChangesAsync();

            //meetings.CommitteeID = await _context.Committees.SingleAsync(Meeting.Committee.CommitteeID);

            return CreatedAtAction("GetMeetings", new { id = meetings.MeetingID }, meetings);
        }

        // DELETE: api/Meetings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMeetings(int id)
        {
            var meetings = await _context.Meetings.FindAsync(id);
            if (meetings == null)
            {
                return NotFound();
            }

            _context.Meetings.Remove(meetings);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MeetingsExists(int id)
        {
            return _context.Meetings.Any(e => e.MeetingID == id);
        }
    }
}
