using Local_Market_Place_001.Data;
using Local_Market_Place_001.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Local_Market_Place_001.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SerachShopController : ControllerBase
    {
        private readonly Local_Market_Place_001Context context;

        public SerachShopController(Local_Market_Place_001Context Context)
        {
            context = Context;
        }

        [HttpGet]
        public async Task<ActionResult<List<RegisterShop>>> Get()
        {
            var data = await context.RegisterShop.ToListAsync();
            return Ok(data);
        }


        [HttpGet("{Name}")]
        public  async Task<ActionResult<RegisterShop>> GetbyName(String Name)
        {
            IQueryable<RegisterShop> query = context.RegisterShop;
            if (!string.IsNullOrEmpty(Name))
            {
                query = query.Where(e => e.ShopName.Contains(Name));
            }

             var data=await  query.ToListAsync();
            return Ok(data);

        }
        [HttpGet("location/{location}")]
        public async Task<ActionResult<IEnumerable<RegisterShop>>> GetShopsByLocation(string location)
        {
            IQueryable<RegisterShop> query = context.RegisterShop;

            if (!string.IsNullOrEmpty(location))
            {
                query = query.Where(e => e.PinCode.Contains(location));
            }

            var data = await query.ToListAsync();
            return Ok(data);
        }

        [HttpGet("shopCategory/{shopCategory}")]
       
        public async Task<ActionResult<RegisterShop>> GetbyshopCategory(String shopCategory)
        {
            IQueryable<RegisterShop> query = context.RegisterShop;

            if (!string.IsNullOrEmpty(shopCategory))
            {
                query = query.Where(e => e.ShopCategory.Contains(shopCategory));
            }

            var data = await query.ToListAsync();
            return Ok(data);

        }


    }
}
