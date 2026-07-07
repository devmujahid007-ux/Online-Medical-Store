using MedicalStore.Models;
using Microsoft.EntityFrameworkCore;

namespace MedicalStore.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<SellOrder> SellOrders { get; set; }
        public DbSet<SellItem> SellItems { get; set; }
        public DbSet<MedicalStore.Models.User> Users { get; set; }
        public DbSet<Company> Companies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Stock>()
                .Property(p => p.Price)
                .HasPrecision(18, 2);

            modelBuilder.Entity<SellItem>()
                .Property(p => p.Price)
                .HasPrecision(18, 2);
        }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //    modelBuilder.Entity<SellItem>()
        //        .HasOne(si => si.SellOrder)
        //        .WithMany(so => so.Items)
        //        .HasForeignKey(si => si.SellOrderId)
        //        .OnDelete(DeleteBehavior.Cascade);
        //}

    }
}


