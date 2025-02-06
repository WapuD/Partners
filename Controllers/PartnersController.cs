using System;
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
    public class PartnersController : ControllerBase
    {
        private readonly DBContext _context;

        public PartnersController(DBContext context)
        {
            _context = context;
        }

        // GET: api/Partners
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Partner>>> GetPartnerAsync()
        {
            return await _context.Partner.ToListAsync();
        }

        // GET: api/Partners/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Partner>> GetPartnerAsync(int id)
        {
            var partner = await _context.Partner.FindAsync(id);

            if (partner == null) { return NotFound(); }

            return partner;
        }

        // GET: api/Partners/Discount/5
        [HttpGet("Discount/{id}")]
        public async Task<ActionResult<int>> GetPartnerDiscountAsync(int id)
        {
            var sells = 0;
            var discount = 0;
            var partner = await _context.Partner.FindAsync(id);
            var orders = await _context.Order.Where(o => o.PartnerId == id).ToListAsync();
            foreach (var order in orders)
            {
                var product = await _context.Product.FindAsync(order.ProductId);
                sells += Convert.ToInt32(product.MinCost * order.Count);
            }
            if (partner == null) { return NotFound(); }
            if (10000 <= sells || sells < 50000) { discount = 5; }
            else if (50000 <= sells || sells < 300000) { discount = 10; }
            else if (300000 <= sells) { discount = 15; }
            else { discount = 0; }
            return discount;
        }

        // PUT: api/Partners/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{partner}")]
        public async Task<IActionResult> PutPartner(Partner partner)
        {
            _context.Entry(partner).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PartnerExists(partner.Id))
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

        // POST: api/Partners/partner
        [HttpPost("{partner}")]
        public async Task<ActionResult<Partner>> AddPartnerAsync(Partner partner)
        {
            _context.Partner.Add(partner);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPartner", new { id = partner.Id }, partner);
        }

        // DELETE: api/Partners/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePartner(int id)
        {
            var partner = await _context.Partner.FindAsync(id);
            if (partner == null)
            {
                return NotFound();
            }

            _context.Partner.Remove(partner);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PartnerExists(int id)
        {
            return _context.Partner.Any(e => e.Id == id);
        }
    }
}
