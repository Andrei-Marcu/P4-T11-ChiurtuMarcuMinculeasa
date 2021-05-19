using LibraryManagement.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagement.Data
{
    public class ApplicationDbContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Subsidiary> Subsidiaries { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<City>().HasData(CityData.Cities);
        }
    }
}
