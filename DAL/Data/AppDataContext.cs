using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Data
{
    public class AppDataContext : IdentityDbContext<User>
    {
        private readonly IConfiguration _configuration;

        public AppDataContext(DbContextOptions<AppDataContext> options, IConfiguration configuration)
            : base(options)
        {
            _configuration = configuration;
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Delivery> Deliveries { get; set; }
      




        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Data Source=(localdb)\\ProjectModels;Initial Catalog=RikMortyApp;Integrated Security=True");
        //    //optionsBuilder.UseSqlServer(_configuration["AppDB"]);
        //}




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<DeliveryProducts>(entity =>
            {
                entity.HasKey(c => new { c.ProductId, c.DeliveryId});
            });

            var delivery = modelBuilder.Entity<Delivery>();
            delivery
                .HasOne(d => d.Manager)
                .WithMany(d => d.Deliveries)
                .HasForeignKey(d => d.ManagerId);
            delivery
                .HasOne(d => d.DeliveryPersons)
                .WithMany(d=>d.Deliveries)
                .HasForeignKey(d=>d.DeliveryPersonId);
            /* var character =modelBuilder.Entity<Character>();
             character
                 .HasOne(u => u.User)
                 .WithMany(ch => ch.Characters)
                 .HasForeignKey(u => u.UserId);*/
            base.OnModelCreating(modelBuilder);
        }
    }
}
