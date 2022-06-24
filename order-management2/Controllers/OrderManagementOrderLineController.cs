using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using order_management2.Models;

namespace order_management2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderManagementOrderLineController : ControllerBase
    {
        private readonly OrderManagementContext _context;

        public OrderManagementOrderLineController(OrderManagementContext context)
        {
            _context = context;
        }

        // GET: api/OrderManagementOrderLine
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderLine>>> GetOrderLine()
        {
          if (_context.OrderLine == null)
          {
              return NotFound();
          }
            return await _context.OrderLine.ToListAsync();
        }

        // GET: api/OrderManagementOrderLine/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderLine>> GetOrderLine(long id)
        {
          if (_context.OrderLine == null)
          {
              return NotFound();
          }
            var orderLine = await _context.OrderLine.FindAsync(id);

            if (orderLine == null)
            {
                return NotFound();
            }

            return orderLine;
        }

        // PUT: api/OrderManagementOrderLine/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrderLine(long id, OrderLine orderLine)
        {
            if (id != orderLine.Id)
            {
                return BadRequest();
            }

            _context.Entry(orderLine).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderLineExists(id))
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

        // POST: api/OrderManagementOrderLine
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OrderLine>> PostOrderLine(OrderLine orderLine)
        {
          if (_context.OrderLine == null)
          {
              return Problem("Entity set 'OrderManagementContext.OrderLine'  is null.");
          }
            _context.OrderLine.Add(orderLine);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrderLine", new { id = orderLine.Id }, orderLine);
        }

        // DELETE: api/OrderManagementOrderLine/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderLine(long id)
        {
            if (_context.OrderLine == null)
            {
                return NotFound();
            }
            var orderLine = await _context.OrderLine.FindAsync(id);
            if (orderLine == null)
            {
                return NotFound();
            }

            _context.OrderLine.Remove(orderLine);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrderLineExists(long id)
        {
            return (_context.OrderLine?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
