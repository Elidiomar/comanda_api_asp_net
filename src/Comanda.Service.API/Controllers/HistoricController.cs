using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Comanda.Domain.Models.Sale;
using Comanda.Infra.Data.Context;
using Microsoft.AspNetCore.Authorization;

namespace Comanda.Service.API.Controllers
{
    
    public class HistoricController : BaseApiController
    {
        private readonly ComandaDbContext _context;

        public HistoricController(ComandaDbContext context)
        {
            _context = context;
        }

        // GET: api/Historic
        [HttpGet]
        public IEnumerable<Historic> GetHistorics()
        {
            return _context.Historics;
        }

        // GET: api/Historic/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetHistoric([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var historic = await _context.Historics.FindAsync(id);

            if (historic == null)
            {
                return NotFound();
            }

            return Ok(historic);
        }

        // PUT: api/Historic/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHistoric([FromRoute] Guid id, [FromBody] Historic historic)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != historic.Id)
            {
                return BadRequest();
            }

            _context.Entry(historic).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HistoricExists(id))
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

        // POST: api/Historic
        [HttpPost]
        public async Task<IActionResult> PostHistoric([FromBody] Historic historic)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Historics.Add(historic);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHistoric", new { id = historic.Id }, historic);
        }

        // DELETE: api/Historic/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHistoric([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var historic = await _context.Historics.FindAsync(id);
            if (historic == null)
            {
                return NotFound();
            }

            _context.Historics.Remove(historic);
            await _context.SaveChangesAsync();

            return Ok(historic);
        }

        private bool HistoricExists(Guid id)
        {
            return _context.Historics.Any(e => e.Id == id);
        }
    }
}