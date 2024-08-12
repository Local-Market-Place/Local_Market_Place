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
    public class RegisterShopsController : ControllerBase
    {
        private readonly Local_Market_Place_001Context _context;

        public RegisterShopsController(Local_Market_Place_001Context context)
        {
            _context = context;
        }

        // GET: api/RegisterShops
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RegisterShop>>> GetRegisterShop()
        {
            return await _context.RegisterShop.ToListAsync();
        }

        // GET: api/RegisterShops/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RegisterShop>> GetRegisterShop(int id)
        {
            var registerShop = await _context.RegisterShop.FindAsync(id);

            if (registerShop == null)
            {
                return NotFound();
            }

            return registerShop;
        }

        // PUT: api/RegisterShops/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRegisterShop(int id, RegisterShop registerShop)
        {
            if (id != registerShop.ShopAddId)
            {
                return BadRequest();
            }

            _context.Entry(registerShop).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RegisterShopExists(id))
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

        // POST: api/RegisterShops
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RegisterShop>> PostRegisterShop(RegisterShop registerShop)
        {
            _context.RegisterShop.Add(registerShop);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRegisterShop", new { id = registerShop.ShopAddId }, registerShop);
        }

        // DELETE: api/RegisterShops/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRegisterShop(int id)
        {
            var registerShop = await _context.RegisterShop.FindAsync(id);
            if (registerShop == null)
            {
                return NotFound();
            }

            _context.RegisterShop.Remove(registerShop);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RegisterShopExists(int id)
        {
            return _context.RegisterShop.Any(e => e.ShopAddId == id);
        }
    }
}
