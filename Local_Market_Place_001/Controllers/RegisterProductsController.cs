using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Local_Market_Place_001.Data;
using Local_Market_Place_001.Models;

namespace Local_Market_Place_001.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterProductsController : ControllerBase
    {
        private readonly Local_Market_Place_001Context _context;

        public RegisterProductsController(Local_Market_Place_001Context context)
        {
            _context = context;
        }

        // GET: api/RegisterProducts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RegisterProduct>>> GetRegisterProduct()
        {
            return await _context.RegisterProduct.ToListAsync();
        }

        // GET: api/RegisterProducts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RegisterProduct>> GetRegisterProduct(int id)
        {
            var registerProduct = await _context.RegisterProduct.FindAsync(id);

            if (registerProduct == null)
            {
                return NotFound();
            }

            return registerProduct;
        }

        // PUT: api/RegisterProducts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRegisterProduct(int id, RegisterProduct registerProduct)
        {
            if (id != registerProduct.ProductId)
            {
                return BadRequest();
            }

            _context.Entry(registerProduct).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RegisterProductExists(id))
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

        // POST: api/RegisterProducts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RegisterProduct>> PostRegisterProduct(RegisterProduct registerProduct)
        {
            _context.RegisterProduct.Add(registerProduct);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRegisterProduct", new { id = registerProduct.ProductId }, registerProduct);
        }

        // DELETE: api/RegisterProducts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRegisterProduct(int id)
        {
            var registerProduct = await _context.RegisterProduct.FindAsync(id);
            if (registerProduct == null)
            {
                return NotFound();
            }

            _context.RegisterProduct.Remove(registerProduct);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RegisterProductExists(int id)
        {
            return _context.RegisterProduct.Any(e => e.ProductId == id);
        }
    }
}
