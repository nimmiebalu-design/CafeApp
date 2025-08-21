using CafeApp.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeApp.Infrastructure.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<CafeEntity> Cafes { get; set; } = null!;
        public DbSet<EmployeeEntity> Employees { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Employee constraints
            modelBuilder.Entity<EmployeeEntity>(entity =>
            {
                entity.HasKey(e => e.id);

                entity.Property(e => e.id)
                      .HasMaxLength(10);
                entity.Property(e => e.name)
                      .IsRequired()
                      .HasMaxLength(100);
                entity.Property(e => e.email_address)
                      .IsRequired()
                       .HasMaxLength(100);
                entity.Property(e => e.phone_number)
                      .IsRequired()
                       .HasMaxLength(8);

                entity.HasOne(e => e.cafe)
                      .WithMany(c => c.Employees)
                      .HasForeignKey(e => e.cafe_id)
                      .IsRequired(false)
                      .OnDelete(DeleteBehavior.Restrict);
            });
            //seed data
            modelBuilder.Entity<CafeEntity>().HasData(
                new CafeEntity
                {
                    id = Guid.Parse("FF40F939-52BB-4511-AA3B-07B519403A08"),
                    name = "Cafe Mocha",
                    description = "A cozy cafe with a variety of coffee and snacks.",
                    logo = null, // Assuming logo is optional and can be null
                    location = "Downtown"
                },
                new CafeEntity
                {
                    id = Guid.Parse("AEE86791-D668-408D-BFD6-43543CF24A73"),
                    name = "Cafe Latte",
                    description = "A cozy cafe with a variety of coffee and snacks.",
                    logo = null,    // Assuming logo is optional and can be null
                    location = "Downtown"
                },
                new CafeEntity
                {
                    id = Guid.Parse("905DD236-C348-4D3B-AC3E-923AFED6E3DE"),
                    name = "Cafe Espresso",
                    description = "A small cafe specializing in espresso drinks.",
                    logo = null, // Assuming logo is optional and can be null
                    location = "Uptown"
                },
                new CafeEntity
                {
                    id = Guid.Parse("FAE99B40-7623-42C2-B6F3-D01CA8C7D784"),
                    name = "Cafe Americano",
                    description = "A cafe known for its American-style coffee.",
                    logo = null, // Assuming logo is optional and can be null
                    location = "Uptown"
                });
            modelBuilder.Entity<EmployeeEntity>().HasData(
                new EmployeeEntity
                {
                    id = "E001",
                    name = "John Doe",
                    email_address = "Johndoe@gmail.com",
                    phone_number = "81234567",
                    gender = "Male",
                    cafe_id = Guid.Parse("FF40F939-52BB-4511-AA3B-07B519403A08"),
                    start_date = DateTime.Parse("2025-08-18 09:30:00")
                },
                  new EmployeeEntity
                  {
                      id = "E002",
                      name = "Jane Smith",
                      email_address = "JaneSmith@gmail.com",
                      phone_number = "81234568",
                      gender = "Male",
                      cafe_id = Guid.Parse("FF40F939-52BB-4511-AA3B-07B519403A08"),
                      start_date = DateTime.Parse("2025-08-18 09:30:00")
                  },
                  new EmployeeEntity
                  {
                      id = "E003",
                      name = "Alice Johnson",
                      email_address = "Alice@gmail.com",
                      phone_number = "81234569",
                      gender = "Male",
                      cafe_id = Guid.Parse("905DD236-C348-4D3B-AC3E-923AFED6E3DE"),
                      start_date = DateTime.Parse("2025-08-19 07:30:00")
                  },
                  new EmployeeEntity
                  {
                      id = "E004",
                      name = "Bob Brown",
                      email_address = "Bob@gmail.com",
                      phone_number = "81234570",
                      gender = "Male",
                      cafe_id = Guid.Parse("FAE99B40-7623-42C2-B6F3-D01CA8C7D784"),
                      start_date = DateTime.Parse("2025-08-20 08:30:00")
                  },
                  new EmployeeEntity
                  {
                      id = "E005",
                      name = "Christina",
                      email_address = "Christina@gmail.com",
                      phone_number = "81234571",
                      gender = "Female",
                      cafe_id = Guid.Parse("FAE99B40-7623-42C2-B6F3-D01CA8C7D784"),
                      start_date = DateTime.Parse("2025-08-21 10:30:00")
                  },
                  new EmployeeEntity
                  {
                      id = "E006",
                      name = "Diana",
                      email_address = "Diana@gmail.com",
                      phone_number = "81234572",
                      gender = "Female",
                      cafe_id = null,
                      start_date = null
                  }
                  );
        }
    }
}