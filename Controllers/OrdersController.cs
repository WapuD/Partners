﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Partner_API.Data;
using Partner_API.Data.Models;
using static NuGet.Packaging.PackagingConstants;

namespace Partner_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly DBContext _context;

        public OrdersController(DBContext context)
        {
            _context = context;
        }

        // GET: api/Orders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrder()
        {
            var orders = await _context.Order.ToListAsync();
            if (orders == null) {return NotFound();}

            foreach (var order in orders)
            {
                order.Partner = await _context.Partner.FindAsync(order.PartnerId);
                order.Product = await _context.Product.FindAsync(order.ProductId);
            }
            return orders;
        }

        // Get("/Orders/History/{id}")
        [HttpGet("History/{id}")]
        public async Task<ActionResult<IEnumerable<Order>>> GetHistoryAsync(int id)
        {
            var orders = await _context.Order.Where(o => o.PartnerId == id).ToListAsync();

            if (orders == null) { return NotFound(); }

            foreach (var order in orders)
            {
                order.Partner = await _context.Partner.FindAsync(order.PartnerId);
                order.Product = await _context.Product.FindAsync(order.ProductId);
                order.Product.ProductType = await _context.ProductType.FindAsync(order.Product.ProductTypeId);
            }
            return orders;
        }

        // GET: api/Orders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrder(int id)
        {
            var order = await _context.Order.FindAsync(id);
            if (order == null) { return NotFound(); }

            order.Partner = await _context.Partner.FindAsync(order.PartnerId);
            order.Product = await _context.Product.FindAsync(order.ProductId);

            return order;
        }

        // PUT: api/Orders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrder(int id, Order order)
        {
            if (id != order.Id){return BadRequest();}

            _context.Entry(order).State = EntityState.Modified;

            try{await _context.SaveChangesAsync();}
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(id)){return NotFound();}
                else{throw;}
            }

            return NoContent();
        }

        // POST: api/Orders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Order>> PostOrder(Order order)
        {
            _context.Order.Add(order);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrder", new { id = order.Id }, order);
        }

        // DELETE: api/Orders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var order = await _context.Order.FindAsync(id);
            if (order == null){return NotFound();}

            _context.Order.Remove(order);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrderExists(int id)
        {
            return _context.Order.Any(e => e.Id == id);
        }
    }
}
