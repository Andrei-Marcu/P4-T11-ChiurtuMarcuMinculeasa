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
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<Cart> Carts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<City>().HasData(CityData.Cities);
            builder.Entity<IdentityRole<int>>().HasData(
                new IdentityRole<int> { Id = 1, Name = "User", NormalizedName = "User".ToUpper(), ConcurrencyStamp = "fcdf80b3-9078-4225-a0ed-24685976ea0c" },
                new IdentityRole<int> { Id = 2, Name = "Administrator", NormalizedName = "Administrator".ToUpper(), ConcurrencyStamp = "4330b7a8-097e-49f1-ad00-ec8553d3a413" }
            );

            builder.Entity<Stock>().HasKey(stock => new { stock.BookID, stock.SubsidiaryID });
            builder.Entity<Cart>().HasKey(cart => new { cart.BookID, cart.UserID });
        }
    }
}
