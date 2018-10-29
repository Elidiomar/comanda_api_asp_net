using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Comanda.Domain.Models.Identity;
using Comanda.Infra.Data.Context;

namespace Comanda.Service.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ComandaDbContext _context;

        public UserController(ComandaDbContext context)
        {
            _context = context;
        }

        // GET: api/User
        [HttpGet]
        public IEnumerable<UserIdentity> GetUsers()
        {
            return _context.Users;
        }

        // GET: api/User/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserIdentity([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userIdentity = await _context.Users.FindAsync(id);

            if (userIdentity == null)
            {
                return NotFound();
            }

            return Ok(userIdentity);
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserIdentity([FromRoute] string id, [FromBody] UserIdentity userIdentity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != userIdentity.Id)
            {
                return BadRequest();
            }

            _context.Entry(userIdentity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserIdentityExists(id))
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

        // POST: api/User
        [HttpPost]
        public async Task<IActionResult> PostUserIdentity([FromBody] UserIdentity userIdentity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Users.Add(userIdentity);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UserIdentityExists(userIdentity.Id))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetUserIdentity", new { id = userIdentity.Id }, userIdentity);
        }

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserIdentity([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userIdentity = await _context.Users.FindAsync(id);
            if (userIdentity == null)
            {
                return NotFound();
            }

            _context.Users.Remove(userIdentity);
            await _context.SaveChangesAsync();

            return Ok(userIdentity);
        }

        private bool UserIdentityExists(string id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}