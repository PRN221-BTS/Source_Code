using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Model.DAOs;

public partial class BirdTransportationSystemContext : DbContext
{
    public BirdTransportationSystemContext()
    {
    }

    public BirdTransportationSystemContext(DbContextOptions<BirdTransportationSystemContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Bird> Birds { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<Route> Routes { get; set; }

    public virtual DbSet<Shipper> Shippers { get; set; }

    public virtual DbSet<TrackingOrder> TrackingOrders { get; set; }

    public virtual DbSet<Warehouse> Warehouses { get; set; }

    public virtual DbSet<WarehouseManager> WarehouseManagers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server =(local) ; database = BirdTransportationSystem ;uid=sa ;pwd=12345 ;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Bird>(entity =>
        {
            entity.HasKey(e => e.BirdId).HasName("PK__Bird__7694332E91D03980");

            entity.ToTable("Bird");

            entity.Property(e => e.BirdId)
                .ValueGeneratedNever()
                .HasColumnName("BirdID");
            entity.Property(e => e.BirdName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.BirdType)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Weight).HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__Customer__A4AE64B83A4E0624");

            entity.ToTable("Customer");

            entity.Property(e => e.CustomerId)
                .ValueGeneratedNever()
                .HasColumnName("CustomerID");
            entity.Property(e => e.CustomerName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__Order__C3905BAF9215526D");

            entity.ToTable("Order");

            entity.Property(e => e.OrderId)
                .ValueGeneratedNever()
                .HasColumnName("OrderID");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.Note)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.PaymentId).HasColumnName("PaymentID");
            entity.Property(e => e.ReceivingAddress)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.RouteId).HasColumnName("RouteID");
            entity.Property(e => e.SendingAddress)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Customer).WithMany(p => p.Orders)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK__Order__CustomerI__32E0915F");

            entity.HasOne(d => d.Payment).WithMany(p => p.Orders)
                .HasForeignKey(d => d.PaymentId)
                .HasConstraintName("FK__Order__PaymentID__34C8D9D1");

            entity.HasOne(d => d.Route).WithMany(p => p.Orders)
                .HasForeignKey(d => d.RouteId)
                .HasConstraintName("FK__Order__RouteID__33D4B598");
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.HasKey(e => e.OrderDetailId).HasName("PK__OrderDet__D3B9D30CBBB7AE75");

            entity.ToTable("OrderDetail");

            entity.Property(e => e.OrderDetailId)
                .ValueGeneratedNever()
                .HasColumnName("OrderDetailID");
            entity.Property(e => e.BirdCage)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.BirdId).HasColumnName("BirdID");
            entity.Property(e => e.Certificate)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DeliveryStatus)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.OtherItems)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Bird).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.BirdId)
                .HasConstraintName("FK__OrderDeta__BirdI__3E52440B");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK__OrderDeta__Order__3D5E1FD2");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.PaymentId).HasName("PK__Payment__9B556A5882819914");

            entity.ToTable("Payment");

            entity.Property(e => e.PaymentId)
                .ValueGeneratedNever()
                .HasColumnName("PaymentID");
            entity.Property(e => e.PaymentDate).HasColumnType("date");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Route>(entity =>
        {
            entity.HasKey(e => e.RouteId).HasName("PK__Route__80979AAD892CE722");

            entity.ToTable("Route");

            entity.Property(e => e.RouteId)
                .ValueGeneratedNever()
                .HasColumnName("RouteID");
            entity.Property(e => e.Distance).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ShipperId).HasColumnName("ShipperID");
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Shipper).WithMany(p => p.Routes)
                .HasForeignKey(d => d.ShipperId)
                .HasConstraintName("FK__Route__ShipperID__300424B4");
        });

        modelBuilder.Entity<Shipper>(entity =>
        {
            entity.HasKey(e => e.ShipperId).HasName("PK__Shipper__1F8AFFB9CC02DBDA");

            entity.ToTable("Shipper");

            entity.Property(e => e.ShipperId)
                .ValueGeneratedNever()
                .HasColumnName("ShipperID");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Income).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.ShipperName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.VehicleType)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.WarehouseId).HasColumnName("WarehouseID");

            entity.HasOne(d => d.Warehouse).WithMany(p => p.Shippers)
                .HasForeignKey(d => d.WarehouseId)
                .HasConstraintName("FK__Shipper__Warehou__2D27B809");
        });

        modelBuilder.Entity<TrackingOrder>(entity =>
        {
            entity.HasKey(e => e.TrackingOrderId).HasName("PK__Tracking__24D0CD62218A5278");

            entity.ToTable("TrackingOrder");

            entity.Property(e => e.TrackingOrderId)
                .ValueGeneratedNever()
                .HasColumnName("TrackingOrderID");
            entity.Property(e => e.ActualDeliveryDate).HasColumnType("date");
            entity.Property(e => e.EstimateDeliveryDate).HasColumnType("date");
            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.TrackingStatus)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.WarehouseId).HasColumnName("WarehouseID");

            entity.HasOne(d => d.Order).WithMany(p => p.TrackingOrders)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK__TrackingO__Order__38996AB5");

            entity.HasOne(d => d.Warehouse).WithMany(p => p.TrackingOrders)
                .HasForeignKey(d => d.WarehouseId)
                .HasConstraintName("FK__TrackingO__Wareh__37A5467C");
        });

        modelBuilder.Entity<Warehouse>(entity =>
        {
            entity.HasKey(e => e.WarehouseId).HasName("PK__Warehous__2608AFD96754C81E");

            entity.ToTable("Warehouse");

            entity.Property(e => e.WarehouseId)
                .ValueGeneratedNever()
                .HasColumnName("WarehouseID");
            entity.Property(e => e.Location)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.WarehouseManagerId).HasColumnName("WarehouseManagerID");
            entity.Property(e => e.WarehouseName)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.WarehouseManager).WithMany(p => p.Warehouses)
                .HasForeignKey(d => d.WarehouseManagerId)
                .HasConstraintName("FK__Warehouse__Wareh__2A4B4B5E");
        });

        modelBuilder.Entity<WarehouseManager>(entity =>
        {
            entity.HasKey(e => e.WarehouseManagerId).HasName("PK__Warehous__678D8266916F9342");

            entity.ToTable("WarehouseManager");

            entity.Property(e => e.WarehouseManagerId)
                .ValueGeneratedNever()
                .HasColumnName("WarehouseManagerID");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.WarehouseManagerName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
