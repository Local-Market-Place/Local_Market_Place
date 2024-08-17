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
    public class ShopServiceLoginsController : ControllerBase
    {
        private readonly Local_Market_Place_001Context _context;

        public ShopServiceLoginsController(Local_Market_Place_001Context context)
        {
            _context = context;
        }

        // GET: api/ShopServiceLogins
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShopServiceLogin>>> GetShopServiceLogin()
        {
            return await _context.ShopServiceLogin.ToListAsync();
        }

        [HttpGet("{mobileno},{password}")]
        public IActionResult GetUserLogin(string mobileno, string password)
        {
            bool userExists = _context.ShopServiceLogin.Any(e => e.MobileNo == mobileno && e.Password == password);

            if (userExists)
            {
                return Ok(true);
            }
            else
            {
                return NotFound(false);
            }
        }

        // PUT: api/ShopServiceLogins/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShopServiceLogin(int id, ShopServiceLogin shopServiceLogin)
        {
            if (id != shopServiceLogin.ShopServiceLoginID)
            {
                return BadRequest();
            }

            _context.Entry(shopServiceLogin).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShopServiceLoginExists(id))
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

        // POST: api/ShopServiceLogins
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ShopServiceLogin>> PostShopServiceLogin(ShopServiceLogin shopServiceLogin)
        {
            _context.ShopServiceLogin.Add(shopServiceLogin);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetShopServiceLogin", new { id = shopServiceLogin.ShopServiceLoginID }, shopServiceLogin);
        }

        private bool ShopServiceLoginExists(int id)
        {
            return _context.ShopServiceLogin.Any(e => e.ShopServiceLoginID == id);
        }
    }
}
