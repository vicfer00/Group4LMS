using LibrarySystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibrarySystem.Data
{
    public class LibraryContext :DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Checkout> Checkouts { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().ToTable("Book");
            modelBuilder.Entity<Checkout>().ToTable("Checkout");
            modelBuilder.Entity<Member>().ToTable("Member");
            modelBuilder.Entity<Room>().ToTable("Room");
            modelBuilder.Entity<Reservation>().ToTable("Reservation");
        }

        public DbSet<LibrarySystem.Models.Room> Room { get; set; }

        public DbSet<LibrarySystem.Models.Reservation> Reservation { get; set; }
    }
}
