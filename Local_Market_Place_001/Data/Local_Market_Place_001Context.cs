﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Loacal_Market_Place.Models;
using Local_Market_Place_001.Models;

namespace Local_Market_Place_001.Data
{
    public class Local_Market_Place_001Context : DbContext
    {
        public Local_Market_Place_001Context (DbContextOptions<Local_Market_Place_001Context> options)
            : base(options)
        {
        }

        public DbSet<Loacal_Market_Place.Models.RegisterService> RegisterService { get; set; } = default!;
        public DbSet<Local_Market_Place_001.Models.RegisterShop> RegisterShop { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure unique constraint for AadharNo
            modelBuilder.Entity<RegisterShopInfo>()
                .HasIndex(r => r.AadharNo)
                .IsUnique();
        }
        public DbSet<Local_Market_Place_001.Models.RegisterShopInfo> RegisterShopInfo { get; set; } = default!;
        public DbSet<Local_Market_Place_001.Models.RegisterProduct> RegisterProduct { get; set; } = default!;
        public DbSet<Local_Market_Place_001.Models.ShopServiceLogin> ShopServiceLogin { get; set; } = default!;
        public DbSet<Local_Market_Place_001.Models.UserLogin> UserLogin { get; set; } = default!;

    }
}
