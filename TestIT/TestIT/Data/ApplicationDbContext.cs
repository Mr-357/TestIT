using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TestIT.Models;

namespace TestIT.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<TestIT.Models.Form> Form { get; set; }
        public DbSet<TestIT.Models.Quiz> Quiz { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<TextAnswer>();
            builder.Entity<PictureAnswer>();
            builder.Entity<RegionAnswer>();

            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
