using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace GameshopWeb.Db
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Game> Games { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Company> Companies { get; set; }

        public DbSet<Order> Orders { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>().ToTable("Game");
            modelBuilder.Entity<Genre>().ToTable("Genre");
            modelBuilder.Entity<Company>().ToTable("Company");
            modelBuilder.Entity<Order>().ToTable("Order");
            modelBuilder.Entity<OrderDetail>().ToTable("OrderDetail");
            modelBuilder.Entity<User>().ToTable("User");

            //relacija između Game i Genre
            modelBuilder.Entity<Game>().HasOne(g => g.Genre).WithMany()
                .HasForeignKey(g => g.IdGenre);
            //relacija game - developer
            modelBuilder.Entity<Game>().HasOne(g => g.Developer).WithMany()
                .HasForeignKey(g => g.IdDeveloper);
            //relacija game - publisher
            modelBuilder.Entity<Game>().HasOne(g => g.Publisher).WithMany()
                .HasForeignKey(g => g.IdPublisher);
            //relacija order-orderdetail
            modelBuilder.Entity<Order>().HasMany(o => o.Details).WithOne()
                .HasForeignKey(d => d.IdOrder);
            //relacija order - user
            modelBuilder.Entity<Order>().HasOne(o => o.User).WithMany()
                .HasForeignKey(o => o.IdUser);
        }
    }
}
