using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TestApp.DAL.EF;

public partial class TestContext : DbContext
{
    public TestContext()
    {
    }

    public TestContext(DbContextOptions<TestContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CustomerOrder> CustomerOrders { get; set; }

    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\aprox\\source\\repos\\TestApp.PL\\TestApp.DAL\\Database\\TestDB.mdf;Integrated Security=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CustomerOrder>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Customer__3214EC07869043E0");

            entity.ToTable("CustomerOrder");

            entity.Property(e => e.CustomerName)
                .HasMaxLength(40)
                .UseCollation("Cyrillic_General_CI_AS");
            entity.Property(e => e.OrderDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__OrderDet__3214EC07E7D06652");

            entity.Property(e => e.Amount).HasDefaultValueSql("((1))");
            entity.Property(e => e.TotalPrice).HasColumnType("decimal(18, 0)");

            entity.HasKey(e => e.Id).HasName("PK__OrderDet__3214EC07E7D06652");

            entity.Property(e => e.Amount).HasDefaultValueSql("((1))");
            entity.Property(e => e.TotalPrice).HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.CustomerOrder).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.CustomerOrderId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__OrderDeta__Custo__3F466844");

            entity.HasOne(d => d.Product).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OrderDeta__Produ__3E52440B");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Product__3214EC0792B1A353");

            entity.ToTable("Product");

            entity.Property(e => e.Description)
                .HasMaxLength(256)
                .UseCollation("Cyrillic_General_CI_AS");
            entity.Property(e => e.Name)
                .HasMaxLength(64)
                .UseCollation("Cyrillic_General_CI_AS");
            entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
