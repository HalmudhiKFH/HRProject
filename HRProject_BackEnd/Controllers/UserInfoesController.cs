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
    [Route("api/UserInfoes")]
    [ApiController]
    public class UserInfoesController : ControllerBase
    {
        private readonly CommitteeDBContext _context;

        public UserInfoesController(CommitteeDBContext context)
        {
            _context = context;
        }

        // GET: api/UserInfoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserInfo>>> GetUserInfoes()
        {
            return await _context.UserInfoes.ToListAsync();
        }

        // GET: api/UserInfoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserInfo>> GetUserInfoes(int id)
        {
            var userInfoes = await _context.UserInfoes.FindAsync(id);

            if (userInfoes == null)
            {
                return NotFound();
            }

            return userInfoes;
        }

        // PUT: api/UserInfoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserInfoes(int id, UserInfo userInfoes)
        {
            if (id != userInfoes.UserID)
            {
                return BadRequest();
            }

            _context.Entry(userInfoes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserInfoesExists(id))
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

        // POST: api/UserInfoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserInfo>> PostUserInfoes(UserInfo userInfoes)
        {
            _context.UserInfoes.Add(userInfoes);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UserInfoesExists(userInfoes.UserID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetUserInfoes", new { id = userInfoes.UserID }, userInfoes);
        }

        // DELETE: api/UserInfoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserInfoes(int id)
        {
            var userInfoes = await _context.UserInfoes.FindAsync(id);
            if (userInfoes == null)
            {
                return NotFound();
            }

            _context.UserInfoes.Remove(userInfoes);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserInfoesExists(int id)
        {
            return _context.UserInfoes.Any(e => e.UserID == id);
        }
    }
}
