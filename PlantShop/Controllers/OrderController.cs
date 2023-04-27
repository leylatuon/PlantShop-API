using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlantShop.Models;

namespace PlantShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly PlantShopDBContext _context;

        public OrderController(PlantShopDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<Response>> GetOrders()
        {
            var orders = await _context.Orders.Include(o => o.OrderItems).ToListAsync();
            var response = new Response();
            if (orders == null || orders.Count == 0)
            {
                response.StatusCode = 404;
                response.StatusDescription = "No orders found";
            }
            else if (orders != null && orders.Count > 0)
            {
                response.StatusCode = 200;
                response.StatusDescription = "Retrieved orders successfully";
                response.Orders = orders;
            }
            else
            {
                response.StatusCode = 400;
                response.StatusDescription = "Invalid request";
            }
            return response;
        }

        // GET: api/Order/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Response>> GetOrder(int id)
        {
          if (_context.Orders == null)
          {
              return NotFound();
          }
            var order = await _context.Orders.Include(o => o.OrderItems).Where(o => o.OrderId == id).ToListAsync();
            var response = new Response();

            if (order == null || order.Count == 0)
            {
                response.StatusCode = 404;
                response.StatusDescription = "No order found";
            }
            else if (order != null && order.Count > 0)
            {
                response.StatusCode = 200;
                response.StatusDescription = "Retrieved order successfully";
                response.Orders = order;
            }
            else
            {
                response.StatusCode = 400;
                response.StatusDescription = "Invalid request";
            }
            return response;
        }

        // PUT: api/Order/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<Response>> PutOrder(int id, Order order)
        {
            var response = new Response();

            if (id != order.OrderId)
            {
                return BadRequest();
            }

            _context.Entry(order).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            response.StatusCode = 200;
            response.StatusDescription = "Updated order successfully";
            return NoContent();
        }

        // POST: api/Order
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Response>> PostOrder(Order order)
        {
            if (order == null)
            {
                return BadRequest("Invalid input");
            }

            if (_context.Orders == null)
            {
                return Problem("Entity set 'PlantShopDBContext.Orders' is null.");
            }

            var response = new Response();
            _context.Orders.Add(order);
            try
            {
                await _context.SaveChangesAsync();
                response.Orders = new List<Order> { order };
            }
            catch (DbUpdateConcurrencyException)
            {
                response.StatusCode = 400;
                response.StatusDescription = "Invalid request";
            }

            response.StatusCode = 201;
            response.StatusDescription = "Posted order successfully";
            return response;
        }

        // DELETE: api/Order/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Response>> DeleteOrder(int id)
        {
            if (_context.Orders == null)
            {
                return NotFound();
            }
            var order = await _context.Orders.FindAsync(id);
            var response = new Response();
            if (order == null)
            {
                response.StatusCode = 404;
                response.StatusDescription = "No orders found";
            }
            else if (order != null)
            {
                response.StatusCode = 200;
                response.StatusDescription = "Deleted successfully";
                response.Orders = new List<Order> { order };
                _context.Orders.Remove(order);
            }
            else
            {
                response.StatusCode = 400;
                response.StatusDescription = "Invalid request";
            }
            await _context.SaveChangesAsync();
            return NoContent();
            // Can return a response instead to confirm deletion
        }

        private bool OrderExists(int id)
        {
            return (_context.Orders?.Any(e => e.OrderId == id)).GetValueOrDefault();
        }
    }
}
