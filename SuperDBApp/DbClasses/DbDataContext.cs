using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DbContext;

public partial class DbDataContext : Microsoft.EntityFrameworkCore.DbContext
{
    public DbDataContext()
    {
    }

    public DbDataContext(DbContextOptions<DbDataContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Component> Components { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<CustomerOrder> CustomerOrders { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Manufacture2Component> Manufacture2Components { get; set; }

    public virtual DbSet<Manufacturer> Manufacturers { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Position> Positions { get; set; }

    public virtual DbSet<Service> Services { get; set; }

    public virtual DbSet<Sex> Sexes { get; set; }

    public virtual DbSet<Type> Types { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https: //go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlite("Data Source=C:\\Users\\user\\Desktop\\labs\\04.01\\db_lab2_ind\\company.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Component>(entity =>
        {
            entity.ToTable("Component");

            entity.HasIndex(e => e.Id, "IX_Component_id").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Brand).HasColumnName("brand");
            entity.Property(e => e.Characteristics).HasColumnName("characteristics");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.ManCountry).HasColumnName("man_Country");
            entity.Property(e => e.ManufacturerId).HasColumnName("manufacturer_id");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.ReleaseDate).HasColumnName("release_date");
            entity.Property(e => e.TypeId).HasColumnName("type_id");
            entity.Property(e => e.Warranty)
                .HasDefaultValueSql("'1 мес.'")
                .HasColumnName("warranty");

            entity.HasOne(d => d.ManCountryNavigation).WithMany(p => p.Components)
                .HasForeignKey(d => d.ManCountry)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Manufacturer).WithMany(p => p.Components)
                .HasForeignKey(d => d.ManufacturerId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Type).WithMany(p => p.Components)
                .HasForeignKey(d => d.TypeId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.ToTable("Country");

            entity.HasIndex(e => e.Id, "IX_Country_id").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name).HasColumnName("name");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.ToTable("Customer");

            entity.HasIndex(e => e.Id, "IX_Customer_id").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address).HasColumnName("address");
            entity.Property(e => e.FirstName)
                .HasColumnType("varchar(80)")
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .HasColumnType("varchar(80)")
                .HasColumnName("last_name");
            entity.Property(e => e.Phone).HasColumnName("phone");
            entity.Property(e => e.SecondName)
                .HasColumnType("varchar(80)")
                .HasColumnName("second_name");
        });

        modelBuilder.Entity<CustomerOrder>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("CustomerOrders");

            entity.Property(e => e.ComponentId1).HasColumnName("component_id_1");
            entity.Property(e => e.ComponentId2).HasColumnName("component_id_2");
            entity.Property(e => e.ComponentId3).HasColumnName("component_id_3");
            entity.Property(e => e.CustomerId).HasColumnName("customer_id");
            entity.Property(e => e.DueDate).HasColumnName("due_date");
            entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
            entity.Property(e => e.FirstName)
                .HasColumnType("varchar(80)")
                .HasColumnName("first_name");
            entity.Property(e => e.GeneralWarranty).HasColumnName("general_warranty");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IsExecute)
                .HasColumnType("boolean")
                .HasColumnName("is_execute");
            entity.Property(e => e.IsPayed)
                .HasColumnType("boolean")
                .HasColumnName("is_payed");
            entity.Property(e => e.LastName)
                .HasColumnType("varchar(80)")
                .HasColumnName("last_name");
            entity.Property(e => e.OrderDate).HasColumnName("order_date");
            entity.Property(e => e.PayProportion).HasColumnName("pay_proportion");
            entity.Property(e => e.SecondName)
                .HasColumnType("varchar(80)")
                .HasColumnName("second_name");
            entity.Property(e => e.ServiceId1).HasColumnName("service_id_1");
            entity.Property(e => e.ServiceId2).HasColumnName("service_id_2");
            entity.Property(e => e.ServiceId3).HasColumnName("service_id_3");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.ToTable("Employee");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address).HasColumnName("address");
            entity.Property(e => e.Age).HasColumnName("age");
            entity.Property(e => e.FirstName).HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .HasColumnType("varchar(80)")
                .HasColumnName("last_name");
            entity.Property(e => e.PassportDetails)
                .HasColumnType("varchar(10)")
                .HasColumnName("passport_details");
            entity.Property(e => e.PhoneNumber)
                .HasColumnType("varchar(12)")
                .HasColumnName("phone_number");
            entity.Property(e => e.PositionId).HasColumnName("position_id");
            entity.Property(e => e.SecondName).HasColumnName("second_name");
            entity.Property(e => e.Sex).HasColumnName("sex");

            entity.HasOne(d => d.Position).WithMany(p => p.Employees)
                .HasForeignKey(d => d.PositionId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.SexNavigation).WithMany(p => p.Employees)
                .HasForeignKey(d => d.Sex)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Manufacture2Component>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Manufacture2Component");

            entity.Property(e => e.Brand).HasColumnName("brand");
            entity.Property(e => e.Characteristics).HasColumnName("characteristics");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.ManCountry).HasColumnName("man_Country");
            entity.Property(e => e.ManufacturerId).HasColumnName("manufacturer_id");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.ReleaseDate).HasColumnName("release_date");
            entity.Property(e => e.TypeId).HasColumnName("type_id");
            entity.Property(e => e.Warranty).HasColumnName("warranty");
        });

        modelBuilder.Entity<Manufacturer>(entity =>
        {
            entity.ToTable("Manufacturer");

            entity.HasIndex(e => e.Id, "IX_Manufacturer_id").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name).HasColumnName("name");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => new {e.CustomerId, e.EmployeeId});

            entity.ToTable("Order");

            entity.Property(e => e.CustomerId).HasColumnName("customer_id");
            entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
            entity.Property(e => e.ComponentId1).HasColumnName("component_id_1");
            entity.Property(e => e.ComponentId2).HasColumnName("component_id_2");
            entity.Property(e => e.ComponentId3).HasColumnName("component_id_3");
            entity.Property(e => e.DueDate).HasColumnName("due_date");
            entity.Property(e => e.GeneralWarranty).HasColumnName("general_warranty");
            entity.Property(e => e.IsExecute)
                .HasDefaultValueSql("false")
                .HasColumnType("boolean")
                .HasColumnName("is_execute");
            entity.Property(e => e.IsPayed)
                .HasDefaultValueSql("false")
                .HasColumnType("boolean")
                .HasColumnName("is_payed");
            entity.Property(e => e.OrderDate).HasColumnName("order_date");
            entity.Property(e => e.PayProportion).HasColumnName("pay_proportion");
            entity.Property(e => e.ServiceId1).HasColumnName("service_id_1");
            entity.Property(e => e.ServiceId2).HasColumnName("service_id_2");
            entity.Property(e => e.ServiceId3).HasColumnName("service_id_3");

            entity.HasOne(d => d.ComponentId1Navigation).WithMany(p => p.OrderComponentId1Navigations)
                .HasForeignKey(d => d.ComponentId1);

            entity.HasOne(d => d.ComponentId2Navigation).WithMany(p => p.OrderComponentId2Navigations)
                .HasForeignKey(d => d.ComponentId2);

            entity.HasOne(d => d.ComponentId3Navigation).WithMany(p => p.OrderComponentId3Navigations)
                .HasForeignKey(d => d.ComponentId3);

            entity.HasOne(d => d.Customer).WithMany(p => p.Orders)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Employee).WithMany(p => p.Orders)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.ServiceId1Navigation).WithMany(p => p.OrderServiceId1Navigations)
                .HasForeignKey(d => d.ServiceId1);

            entity.HasOne(d => d.ServiceId2Navigation).WithMany(p => p.OrderServiceId2Navigations)
                .HasForeignKey(d => d.ServiceId2);

            entity.HasOne(d => d.ServiceId3Navigation).WithMany(p => p.OrderServiceId3Navigations)
                .HasForeignKey(d => d.ServiceId3);
        });

        modelBuilder.Entity<Position>(entity =>
        {
            entity.ToTable("Position");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Requirements).HasColumnName("requirements");
            entity.Property(e => e.Responsibilities).HasColumnName("responsibilities");
            entity.Property(e => e.Salary).HasColumnName("salary");
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.ToTable("Service");

            entity.HasIndex(e => e.Id, "IX_Service_id").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Cost).HasColumnName("cost");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Name).HasColumnName("name");
        });

        modelBuilder.Entity<Sex>(entity =>
        {
            entity.ToTable("sex");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name).HasColumnName("name");
        });

        modelBuilder.Entity<Type>(entity =>
        {
            entity.ToTable("Type");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Name).HasColumnName("name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}