﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TestIT.Data;

namespace TestIT.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20190605145242_RoleSeedData")]
    partial class RoleSeedData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");

                    b.HasData(
                        new
                        {
                            Id = "955601ae-b578-4638-9e15-a4652797713b",
                            ConcurrencyStamp = "73da4e3e-bc04-4574-b96c-efb92c72ca3a",
                            Name = "Student"
                        },
                        new
                        {
                            Id = "f5f0979c-c080-4010-923c-0d217820a4f2",
                            ConcurrencyStamp = "ca37b4a3-ced3-4939-8386-32dfdba0dbac",
                            Name = "Profesor"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasMaxLength(128);

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("TestIT.Models.Answer", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<bool>("IsCorrect");

                    b.Property<int?>("QuestionID");

                    b.HasKey("ID");

                    b.HasIndex("QuestionID");

                    b.ToTable("Answer");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Answer");
                });

            modelBuilder.Entity("TestIT.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("Modul");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("TestIT.Models.Course", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Module");

                    b.Property<string>("Name");

                    b.Property<string>("SchoolYear");

                    b.Property<string>("Short");

                    b.HasKey("ID");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("TestIT.Models.Question", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<byte[]>("Picture");

                    b.Property<float>("Points");

                    b.Property<string>("QuestionText");

                    b.Property<int?>("QuizID");

                    b.HasKey("ID");

                    b.HasIndex("QuizID");

                    b.ToTable("Question");
                });

            modelBuilder.Entity("TestIT.Models.Quiz", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ApplicationUserId");

                    b.Property<int?>("CourseID");

                    b.Property<string>("Name");

                    b.Property<int>("Visibility");

                    b.Property<int>("numberOfQustionsPerTry");

                    b.Property<int>("time");

                    b.HasKey("ID");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("CourseID");

                    b.ToTable("Quiz");
                });

            modelBuilder.Entity("TestIT.Models.onCours", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CourseID");

                    b.Property<string>("UserId");

                    b.HasKey("ID");

                    b.HasIndex("CourseID");

                    b.HasIndex("UserId");

                    b.ToTable("onCours");
                });

            modelBuilder.Entity("TestIT.Models.PictureAnswer", b =>
                {
                    b.HasBaseType("TestIT.Models.Answer");

                    b.Property<byte[]>("Picture");

                    b.HasDiscriminator().HasValue("PictureAnswer");
                });

            modelBuilder.Entity("TestIT.Models.RegionAnswer", b =>
                {
                    b.HasBaseType("TestIT.Models.Answer");

                    b.Property<float>("x1");

                    b.Property<float>("x2");

                    b.Property<float>("y1");

                    b.Property<float>("y2");

                    b.HasDiscriminator().HasValue("RegionAnswer");
                });

            modelBuilder.Entity("TestIT.Models.TextAnswer", b =>
                {
                    b.HasBaseType("TestIT.Models.Answer");

                    b.Property<string>("text");

                    b.HasDiscriminator().HasValue("TextAnswer");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("TestIT.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("TestIT.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TestIT.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("TestIT.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TestIT.Models.Answer", b =>
                {
                    b.HasOne("TestIT.Models.Question", "Question")
                        .WithMany("Answers")
                        .HasForeignKey("QuestionID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TestIT.Models.Question", b =>
                {
                    b.HasOne("TestIT.Models.Quiz", "Quiz")
                        .WithMany("Questions")
                        .HasForeignKey("QuizID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TestIT.Models.Quiz", b =>
                {
                    b.HasOne("TestIT.Models.ApplicationUser")
                        .WithMany("Quizzes")
                        .HasForeignKey("ApplicationUserId");

                    b.HasOne("TestIT.Models.Course")
                        .WithMany("Quizzes")
                        .HasForeignKey("CourseID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TestIT.Models.onCours", b =>
                {
                    b.HasOne("TestIT.Models.Course", "Course")
                        .WithMany("Users")
                        .HasForeignKey("CourseID");

                    b.HasOne("TestIT.Models.ApplicationUser", "User")
                        .WithMany("OnCours")
                        .HasForeignKey("UserId");
                });
#pragma warning restore 612, 618
        }
    }
}