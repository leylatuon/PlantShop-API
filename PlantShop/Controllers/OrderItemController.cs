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
    public class OrderItemController : ControllerBase
    {
        private readonly PlantShopDBContext _context;

        public OrderItemController(PlantShopDBContext context)
        {
            _context = context;
        }

        // GET: api/OrderItem
        [HttpGet]
        public async Task<ActionResult<Response>> GetOrderItems()
        {
            var orderitems = await _context.OrderItems.ToListAsync();
            var response = new Response();
            if (orderitems == null || orderitems.Count == 0)
            {
                response.StatusCode = 404;
                response.StatusDescription = "No order items found";
            }
            else if (orderitems != null && orderitems.Count > 0)
            {
                response.StatusCode = 200;
                response.StatusDescription = "Retrieved successfully";
                response.OrderItems = orderitems;
            }
            else
            {
                response.StatusCode = 400;
                response.StatusDescription = "Invalid request";
            }
            return response;
        }

        // GET: api/OrderItem/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Response>> GetOrderItem(int id)
        {
            if (_context.Orders == null)
            {
                return NotFound();
            }
            var orderItem = await _context.OrderItems.FindAsync(id);
            var response = new Response();

            if (orderItem == null)
            {
                response.StatusCode = 404;
                response.StatusDescription = "No order item found";
            }
            else if (orderItem != null)
            {
                response.StatusCode = 200;
                response.StatusDescription = "Retrieved order item successfully";
                response.OrderItems = new List<OrderItem> { orderItem };
            }
            else
            {
                response.StatusCode = 400;
                response.StatusDescription = "Invalid request";
            }
            return response;

        }

        // PUT: api/OrderItem/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<Response>> PutOrderItem(int id, OrderItem orderItem)
        {
            var response = new Response();

            if (id != orderItem.ItemId)
            {
                return BadRequest();
            }

            _context.Entry(orderItem).State = EntityState.Modified;
            var order = await _context.Orders.FindAsync(orderItem.OrderId);
            if (order == null)
            {
                return BadRequest("Invalid OrderId");
            }
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            response.StatusCode = 200;
            response.StatusDescription = "Updated order item successfully";
            return NoContent();
        }

        // POST: api/OrderItem
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Response>> PostOrderItem(OrderItem orderItem)
        {
            if (_context.OrderItems == null)
            {
                return Problem("Entity set 'PlantShopDBContext.OrderItems' is null.");
            }

            var response = new Response();
            var order = await _context.Orders.FindAsync(orderItem.OrderId);
            if (order == null)
            {
                return BadRequest("Invalid OrderId");
            }
            _context.OrderItems.Add(orderItem);
            try
            {
                await _context.SaveChangesAsync();
                response.OrderItems = new List<OrderItem> { orderItem };
            }
            catch (DbUpdateConcurrencyException)
            {
                response.StatusCode = 400;
                response.StatusDescription = "Invalid request";
            }

            response.StatusCode = 201;
            response.StatusDescription = "Posted order item successfully";
            return response;
        }

        // DELETE: api/OrderItem/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Response>> DeleteOrderItem(int id)
        {
            if (_context.OrderItems == null)
            {
                return NotFound();
            }
            var orderItem = await _context.OrderItems.FindAsync(id);
            if (orderItem == null)
            {
                return NotFound();
            }

            _context.OrderItems.Remove(orderItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrderItemExists(int id)
        {
            return (_context.OrderItems?.Any(e => e.ItemId == id)).GetValueOrDefault();
        }
    }
}
