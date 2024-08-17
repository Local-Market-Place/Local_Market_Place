using Local_Market_Place_001.Data;
using Local_Market_Place_001.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Local_Market_Place_001.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchProductController : ControllerBase
    {
        private readonly Local_Market_Place_001Context contextss;

        public SearchProductController(Local_Market_Place_001Context Contextss)
        {
            contextss = Contextss;
        }

        
        [HttpGet("{Name}")]
        public async Task<ActionResult< RegisterProduct>> GetbyNamRegisterProduct (String Name)
        {
            IQueryable< RegisterProduct > query = contextss.RegisterProduct ;
            if (!string.IsNullOrEmpty(Name))
            {
                query = query.Where(e => e.ProductName.Contains(Name));
            }

            var data = await query.ToListAsync();
            return Ok(data);

        }

       


    }
}
