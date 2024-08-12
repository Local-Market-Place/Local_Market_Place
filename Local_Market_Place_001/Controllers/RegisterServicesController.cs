using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Loacal_Market_Place.Models;
using Local_Market_Place_001.Data;

namespace Local_Market_Place_001.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterServicesController : ControllerBase
    {
        private readonly Local_Market_Place_001Context _context;

        public RegisterServicesController(Local_Market_Place_001Context context)
        {
            _context = context;
        }

        // GET: api/RegisterServices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RegisterService>>> GetRegisterService()
        {
            return await _context.RegisterService.ToListAsync();
        }

        // GET: api/RegisterServices/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RegisterService>> GetRegisterService(int id)
        {
            var registerService = await _context.RegisterService.FindAsync(id);

            if (registerService == null)
            {
                return NotFound();
            }

            return registerService;
        }

        // PUT: api/RegisterServices/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRegisterService(int id, RegisterService registerService)
        {
            if (id != registerService.ShopId)
            {
                return BadRequest();
            }

            _context.Entry(registerService).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RegisterServiceExists(id))
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

        // POST: api/RegisterServices
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RegisterService>> PostRegisterService(RegisterService registerService)
        {
            _context.RegisterService.Add(registerService);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRegisterService", new { id = registerService.ShopId }, registerService);
        }

        // DELETE: api/RegisterServices/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRegisterService(int id)
        {
            var registerService = await _context.RegisterService.FindAsync(id);
            if (registerService == null)
            {
                return NotFound();
            }

            _context.RegisterService.Remove(registerService);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RegisterServiceExists(int id)
        {
            return _context.RegisterService.Any(e => e.ShopId == id);
        }
    }
}
