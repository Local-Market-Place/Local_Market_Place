using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Loacal_Market_Place.Models;

namespace Local_Market_Place_001.Data
{
    public class Local_Market_Place_001Context : DbContext
    {
        public Local_Market_Place_001Context (DbContextOptions<Local_Market_Place_001Context> options)
            : base(options)
        {
        }

        public DbSet<Loacal_Market_Place.Models.RegisterService> RegisterService { get; set; } = default!;
    }
}
