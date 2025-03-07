﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Partner_API.Data;
using Partner_API.Data.Models;

namespace Partner_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartnerTypesController : ControllerBase
    {
        private readonly DBContext _context;

        public PartnerTypesController(DBContext context)
        {
            _context = context;
        }

        // GET: api/PartnerTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PartnerType>>> GetPartnerType()
        {
            return await _context.PartnerType.ToListAsync();
        }

        // GET: api/PartnerTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PartnerType>> GetPartnerType(int id)
        {
            var partnerType = await _context.PartnerType.FindAsync(id);

            if (partnerType == null)
            {
                return NotFound();
            }

            return partnerType;
        }

        // PUT: api/PartnerTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPartnerType(int id, PartnerType partnerType)
        {
            if (id != partnerType.Id)
            {
                return BadRequest();
            }

            _context.Entry(partnerType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PartnerTypeExists(id))
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

        // POST: api/PartnerTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PartnerType>> PostPartnerType(PartnerType partnerType)
        {
            _context.PartnerType.Add(partnerType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPartnerType", new { id = partnerType.Id }, partnerType);
        }

        // DELETE: api/PartnerTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePartnerType(int id)
        {
            var partnerType = await _context.PartnerType.FindAsync(id);
            if (partnerType == null)
            {
                return NotFound();
            }

            _context.PartnerType.Remove(partnerType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PartnerTypeExists(int id)
        {
            return _context.PartnerType.Any(e => e.Id == id);
        }
    }
}
