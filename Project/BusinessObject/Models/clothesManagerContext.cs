using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace BusinessObject.Models
{
    public partial class clothesManagerContext : DbContext
    {
        public clothesManagerContext()
        {
        }

        public clothesManagerContext(DbContextOptions<clothesManagerContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<Manager> Managers { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<OrderDetail> OrderDetails { get; set; } = null!;
        public virtual DbSet<Provider> Providers { get; set; } = null!;
        public virtual DbSet<Purchase> Purchases { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", true, true)
    .Build();
            optionsBuilder.UseSqlServer(config.GetConnectionString("Context"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.CustomerName)
                    .HasMaxLength(50)
                    .HasColumnName("Customer Name");

                entity.Property(e => e.Phone).HasMaxLength(50);
            });

            modelBuilder.Entity<Manager>(entity =>
            {
                entity.HasKey(e => e.UserName)
                    .HasName("PK_Table_1");

                entity.ToTable("Manager");

                entity.Property(e => e.UserName)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Password)
                    .HasMaxLength(10)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Order");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.OrderDate).HasColumnType("date");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_Order_Customer");
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.ToTable("OrderDetail");

                entity.Property(e => e.OrderDetailId).HasColumnName("OrderDetailID");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderDetail_Order");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderDetail_Purchase");
            });

            modelBuilder.Entity<Provider>(entity =>
            {
                entity.ToTable("Provider");

                entity.Property(e => e.ProviderId).HasColumnName("ProviderID");

                entity.Property(e => e.Address).HasMaxLength(50);

                entity.Property(e => e.ProviderName).HasMaxLength(50);
            });

            modelBuilder.Entity<Purchase>(entity =>
            {
                entity.HasKey(e => e.ProductId)
                    .HasName("PK__Purchase__B40CC6EDCB974578");

                entity.ToTable("Purchase");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.ProductName).HasMaxLength(50);

                entity.Property(e => e.PurchaseDate).HasColumnType("date");

                entity.Property(e => e.PurchasePrice).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.SalePrice).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.Provider)
                    .WithMany(p => p.Purchases)
                    .HasForeignKey(d => d.ProviderId)
                    .HasConstraintName("FK_Purchase_Provider");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
