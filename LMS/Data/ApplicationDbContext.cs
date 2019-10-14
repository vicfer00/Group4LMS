using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using LMS.Models;

namespace LMS.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<LMS.Models.Book> Book { get; set; }
        public DbSet<LMS.Models.Patron> Patron { get; set; }
        public DbSet<LMS.Models.Checkout> Checkout { get; set; }
        public DbSet<LMS.Models.Room> Room { get; set; }
        public DbSet<LMS.Models.Reservation> Reservation { get; set; }
        //public DbSet<AspNetCore.Areas_Identity_Pages__ViewStart> areas_Identity_Pages__ViewStarts {get;set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Book>().ToTable("Book");
            modelBuilder.Entity<Patron>().ToTable("Patron");
            modelBuilder.Entity<Checkout>().ToTable("Checkout");
            modelBuilder.Entity<Room>().ToTable("Room");
            modelBuilder.Entity<Reservation>().ToTable("Reservation");
            
        }
    }
}
