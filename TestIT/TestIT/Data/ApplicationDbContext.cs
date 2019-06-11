using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TestIT.Models;
using TestIT.Data.Managers;

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
        public DbSet<TestIT.Models.Competition> Competitions { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<TextAnswer>();
            builder.Entity<PictureAnswer>();
            builder.Entity<RegionAnswer>();
            //builder.Entity<Quiz>()
            //    .HasOne(q => q.Course)
            //    .WithMany(c => c.Quizzes);
            //.OnDelete(DeleteBehavior.SetNull);
            builder.Entity<Course>()
                .HasMany(c => c.Quizzes)
                .WithOne(q => q.Course)
                .OnDelete(DeleteBehavior.Cascade);
            builder.Entity<onCours>()
                .HasOne(x => x.User)
                .WithMany(s => s.OnCours).OnDelete(DeleteBehavior.Cascade);
            builder.Entity<onCours>()
                .HasOne(x => x.Course)
                .WithMany(c => c.Users).OnDelete(DeleteBehavior.Cascade);
            builder.Entity<Answer>()
                .HasOne(a => a.Question)
                .WithMany(q => q.Answers)
                .OnDelete(DeleteBehavior.Cascade);
            builder.Entity<Question>()
                .HasOne(q => q.Quiz)
                .WithMany(quiz => quiz.Questions)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Course>()
                .HasMany(c => c.Comments)
                .WithOne(x => x.Course)
                .OnDelete(DeleteBehavior.Cascade);
            builder.Entity<Comment>()
                .HasOne(q => q.ApplicationUser);
           builder.Entity<Comment>()
                .HasOne(q => q.Course)
                .WithMany(c => c.Comments)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Competition>()
                .HasOne(x => x.Quiz)
                .WithMany()
                .OnDelete(DeleteBehavior.SetNull);
            builder.Entity<Competition>()
                .HasMany(x => x.Participations)
                .WithOne(p => p.Competition)
                .OnDelete(DeleteBehavior.SetNull);
            builder.Entity<Participation>()
                .HasOne(x => x.User)
                .WithMany()
                .OnDelete(DeleteBehavior.SetNull);
            builder.Entity<Participation>()
                .HasOne(x => x.Competition)
                .WithMany(c => c.Participations)
                .OnDelete(DeleteBehavior.SetNull);
            //seed Data
            builder.Entity<IdentityRole>()
                .HasData(
                    SeedDataManager.getRoleSeedData()
                );
            builder.Entity<Course>()
                .HasData(
                    SeedDataManager.getCoursSeedData()
                );
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
