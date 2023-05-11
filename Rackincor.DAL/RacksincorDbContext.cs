using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Racksincor.DAL.Models;
using Racksincor.DAL.Models.Abstract;
using Racksincor.DAL.Models.Promotions;

namespace Racksincor.DAL
{
    public class RacksincorDbContext : IdentityDbContext<User>
    {
        public DbSet<Rack> Racks { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<Shop> Shops { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Promotion> Promotions { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<Gift> Gifts { get; set; }
        public DbSet<Reaction> Reactions { get; set; }
        public DbSet<Record> Records { get; set; }

        public RacksincorDbContext(DbContextOptions<RacksincorDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Reaction>()
                .HasKey(sc => new { sc.UserId, sc.ProductId });

            base.OnModelCreating(modelBuilder);
        }
    }
}
