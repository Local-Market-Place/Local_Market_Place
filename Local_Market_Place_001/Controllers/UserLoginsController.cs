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
    public class UserLoginsController : ControllerBase
    {
        private readonly Local_Market_Place_001Context _context;

        public UserLoginsController(Local_Market_Place_001Context context)
        {
            _context = context;
        }

        // GET: api/UserLogins
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserLogin>>> GetUserLogin()
        {
            return await _context.UserLogin.ToListAsync();
        }


        [HttpGet("{mobileno},{password}")]
        public IActionResult GetUserLogin(string mobileno, string password)
        {
            bool userExists = _context.UserLogin.Any(e => e.MobileNo == mobileno && e.Password == password);

            if (userExists)
            {
                return Ok(true);
            }
            else
            {
                return NotFound(false);
            }
        }
    

    [HttpPut("{id}")]
        public async Task<IActionResult> PutUserLogin(int id, UserLogin userLogin)
        {
            if (id != userLogin.UserLoginID)
            {
                return BadRequest();
            }

            _context.Entry(userLogin).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserLoginCheck(id))
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

        // POST: api/UserLogins
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserLogin>> PostUserLogin(UserLogin userLogin)
        {

            // Check if the mobile number already exists in the database
       

           
                _context.UserLogin.Add(userLogin);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetUserLogin", new { id = userLogin.UserLoginID }, userLogin);
       
      


        }


        private bool UserLoginCheck(int id)
        {
            return _context.UserLogin.Any(e => e.UserLoginID == id);
        }
        private bool existingUser(string mobileno)
        {
            return _context.UserLogin.Any(e => e.MobileNo == mobileno);
        }

    }
}
