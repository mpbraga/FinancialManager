using FinancialManager.Data.Interfaces;
using FinancialManager.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace FinancialManager.Data
{
    public class FinancialManagerDbContext : DbContext, IFinancialManagerDbContext
    {
        public FinancialManagerDbContext(DbContextOptions<FinancialManagerDbContext> options)
            : base(options)
        {
            //ChangeTracker.LazyLoadingEnabled = false;
            //ChangeTracker.AutoDetectChangesEnabled = false;
        }

        public DbSet<Supplier> Suppliers { get; set; }

        public DbSet<Bill> Bills { get; set; }

        public string DataSource => Database?.GetDbConnection()?.DataSource;
        public string DatabaseName => Database?.GetDbConnection()?.Database;
        public IDbConnection DbConnection => Database?.GetDbConnection();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseMySQL("server=localhost;database=library;user=user;password=password");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id)
                  .ValueGeneratedOnAdd();
                entity.Property(e => e.Name).IsRequired();
                entity.Property(e => e.Document).IsRequired();
                
            });

            modelBuilder.Entity<Bill>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id)
                  .ValueGeneratedOnAdd();
                entity.Property(e => e.BillingValue).HasPrecision(15, 2);
                entity.Property(e => e.AmountPayed).HasPrecision(15, 2);
                entity.Property(e => e.Type)
                  .HasConversion<string>();
                entity.Property(e => e.PaymentDate)
                  .HasColumnType("date");
                entity.HasOne(e => e.Supplier)
                  .WithMany(e => e.Bills)
                  .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<SupplierFilePattern>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id)
                  .ValueGeneratedOnAdd();
                entity.HasOne(e => e.Supplier)
                  .WithMany(e => e.FilesPatterns)
                  .OnDelete(DeleteBehavior.Cascade);
            });

            // TODO: indexes
        }
    }
}
