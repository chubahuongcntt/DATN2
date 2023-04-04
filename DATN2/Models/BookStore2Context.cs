using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DATN2.Models;

public partial class BookStore2Context : DbContext
{
    public BookStore2Context()
    {
    }

    public BookStore2Context(DbContextOptions<BookStore2Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<Author> Authors { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    public virtual DbSet<Produce> Produces { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<TransitionStatus> TransitionStatuses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.ToTable("accounts");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Active).HasColumnName("active");
            entity.Property(e => e.CreateDate)
                .HasColumnType("date")
                .HasColumnName("createDate");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsFixedLength()
                .HasColumnName("email");
            entity.Property(e => e.LastLogin)
                .HasColumnType("date")
                .HasColumnName("lastLogin");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsFixedLength()
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("password");
            entity.Property(e => e.Phone)
                .HasMaxLength(12)
                .IsFixedLength()
                .HasColumnName("phone");
            entity.Property(e => e.RoleId).HasColumnName("roleId");
            entity.Property(e => e.Salt)
                .HasMaxLength(6)
                .IsFixedLength()
                .HasColumnName("salt");

            entity.HasOne(d => d.Role).WithMany(p => p.Accounts)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK_accounts_role");
        });

        modelBuilder.Entity<Author>(entity =>
        {
            entity.ToTable("author");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(100)
                .HasColumnName("address");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Story)
                .HasMaxLength(500)
                .HasColumnName("story");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.ToTable("category");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Cover)
                .HasMaxLength(100)
                .HasColumnName("cover");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Levels).HasColumnName("levels");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.Odering).HasColumnName("odering");
            entity.Property(e => e.ParentId).HasColumnName("parentId");
            entity.Property(e => e.Published).HasColumnName("published");
            entity.Property(e => e.Thums)
                .HasMaxLength(100)
                .HasColumnName("thums");
            entity.Property(e => e.Title)
                .HasMaxLength(100)
                .HasColumnName("title");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.ToTable("customer");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Active).HasColumnName("active");
            entity.Property(e => e.Address)
                .HasMaxLength(500)
                .HasColumnName("address");
            entity.Property(e => e.Avatar)
                .HasMaxLength(50)
                .HasColumnName("avatar");
            entity.Property(e => e.BirthDay)
                .HasColumnType("date")
                .HasColumnName("birthDay");
            entity.Property(e => e.CreateDate)
                .HasColumnType("date")
                .HasColumnName("createDate");
            entity.Property(e => e.Email)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.LastLogin)
                .HasColumnType("date")
                .HasColumnName("lastLogin");
            entity.Property(e => e.Name)
                .HasMaxLength(500)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .HasColumnName("password");
            entity.Property(e => e.Phone)
                .HasMaxLength(12)
                .IsFixedLength()
                .HasColumnName("phone");
            entity.Property(e => e.Satl)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("satl");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.ToTable("order");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CustomerId).HasColumnName("customerId");
            entity.Property(e => e.Deleted).HasColumnName("deleted");
            entity.Property(e => e.Note)
                .HasMaxLength(500)
                .HasColumnName("note");
            entity.Property(e => e.OrderDate)
                .HasColumnType("date")
                .HasColumnName("orderDate");
            entity.Property(e => e.Paid).HasColumnName("paid");
            entity.Property(e => e.PayDate)
                .HasColumnType("date")
                .HasColumnName("payDate");
            entity.Property(e => e.PayId).HasColumnName("payId");
            entity.Property(e => e.ShipDate)
                .HasColumnType("date")
                .HasColumnName("shipDate");
            entity.Property(e => e.StatusId).HasColumnName("statusId");

            entity.HasOne(d => d.Customer).WithMany(p => p.Orders)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK_order_customer");

            entity.HasOne(d => d.Status).WithMany(p => p.Orders)
                .HasForeignKey(d => d.StatusId)
                .HasConstraintName("FK_order_transitionStatus");
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.ToTable("orderDetail");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Discount).HasColumnName("discount");
            entity.Property(e => e.OrderId).HasColumnName("orderId");
            entity.Property(e => e.OrderNumber).HasColumnName("orderNumber");
            entity.Property(e => e.ProduceId).HasColumnName("produceId");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.ShipDate)
                .HasColumnType("date")
                .HasColumnName("shipDate");
            entity.Property(e => e.Total).HasColumnName("total");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK_orderDetail_order");
        });

        modelBuilder.Entity<Produce>(entity =>
        {
            entity.ToTable("produce");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Active).HasColumnName("active");
            entity.Property(e => e.AutId).HasColumnName("autId");
            entity.Property(e => e.BestSell).HasColumnName("bestSell");
            entity.Property(e => e.CatId).HasColumnName("catId");
            entity.Property(e => e.Desciption)
                .HasMaxLength(500)
                .HasColumnName("desciption");
            entity.Property(e => e.Discount).HasColumnName("discount");
            entity.Property(e => e.HomeFlag).HasColumnName("homeFlag");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.Tag)
                .HasMaxLength(500)
                .HasColumnName("tag");
            entity.Property(e => e.Thumb)
                .HasMaxLength(50)
                .HasColumnName("thumb");
            entity.Property(e => e.UnitslnStock).HasColumnName("unitslnStock");

            entity.HasOne(d => d.Aut).WithMany(p => p.Produces)
                .HasForeignKey(d => d.AutId)
                .HasConstraintName("FK_produce_author");

            entity.HasOne(d => d.Cat).WithMany(p => p.Produces)
                .HasForeignKey(d => d.CatId)
                .HasConstraintName("FK_produce_category");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.ToTable("role");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<TransitionStatus>(entity =>
        {
            entity.ToTable("transitionStatus");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .HasColumnName("description");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasColumnName("status");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
