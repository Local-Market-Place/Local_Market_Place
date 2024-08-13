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
    public class RegisterShopInfoesController : ControllerBase
    {
        private readonly Local_Market_Place_001Context _context;

        public RegisterShopInfoesController(Local_Market_Place_001Context context)
        {
            _context = context;
        }

        // GET: api/RegisterShopInfoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RegisterShopInfo>>> GetRegisterShopInfo()
        {
            return await _context.RegisterShopInfo.ToListAsync();
        }

        // GET: api/RegisterShopInfoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RegisterShopInfo>> GetRegisterShopInfo(int id)
        {
            var registerShopInfo = await _context.RegisterShopInfo.FindAsync(id);

            if (registerShopInfo == null)
            {
                return NotFound();
            }

            return registerShopInfo;
        }

        // PUT: api/RegisterShopInfoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRegisterShopInfo(int id, RegisterShopInfo registerShopInfo)
        {
            if (id != registerShopInfo.RegisterShopInfoID)
            {
                return BadRequest();
            }

            _context.Entry(registerShopInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RegisterShopInfoExists(id))
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

        // POST: api/RegisterShopInfoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RegisterShopInfo>> PostRegisterShopInfo(RegisterShopInfo registerShopInfo)
        {
            _context.RegisterShopInfo.Add(registerShopInfo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRegisterShopInfo", new { id = registerShopInfo.RegisterShopInfoID }, registerShopInfo);
        }

        // DELETE: api/RegisterShopInfoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRegisterShopInfo(int id)
        {
            var registerShopInfo = await _context.RegisterShopInfo.FindAsync(id);
            if (registerShopInfo == null)
            {
                return NotFound();
            }

            _context.RegisterShopInfo.Remove(registerShopInfo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RegisterShopInfoExists(int id)
        {
            return _context.RegisterShopInfo.Any(e => e.RegisterShopInfoID == id);
        }
    }
}
