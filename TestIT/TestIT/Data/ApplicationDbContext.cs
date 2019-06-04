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
        public DbSet<TestIT.Models.Quiz> Quiz { get; set; }
        public DbSet<TestIT.Models.Course> Courses { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<TextAnswer>();
            builder.Entity<PictureAnswer>();
            builder.Entity<RegionAnswer>();
            builder.Entity<Course>()
                .HasMany(c => c.Quizzes)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Answer>()
                .HasOne(a => a.Question)
                .WithMany(q => q.Answers)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Question>()
                .HasOne(q => q.Quiz)
                .WithMany(quiz => quiz.Questions)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
