using Loacal_Market_Place.Models;
using Local_Market_Place_001.Data;
using Local_Market_Place_001.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Local_Market_Place_001.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchServiceController : ControllerBase
    {
        private readonly Local_Market_Place_001Context contexts;

        public SearchServiceController(Local_Market_Place_001Context Contexts)
        {
            contexts = Contexts;
        }



        [HttpGet]
        public async Task<ActionResult<List<RegisterService>>> Get()
        {
            var data = await contexts.RegisterService.ToListAsync();
            return Ok(data);
        }
    }
}
