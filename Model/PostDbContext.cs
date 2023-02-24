using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace NetProviders.Models;

public partial class PostDbContext : DbContext
{
    public PostDbContext()
    {
    }

    public PostDbContext(DbContextOptions<PostDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Provider> Providers { get; set; }

    public virtual DbSet<ProviderBankAccount> ProviderBankAccounts { get; set; }

    public virtual DbSet<ProviderContact> ProviderContacts { get; set; }

    public virtual DbSet<ProviderPaymentsMethod> ProviderPaymentsMethods { get; set; }

    public virtual DbSet<ProviderWarehouse> ProviderWarehouses { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_general_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Provider>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("providers");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(250)
                .HasComment("fiscal address")
                .HasColumnName("address");
            entity.Property(e => e.Cif)
                .HasMaxLength(50)
                .HasColumnName("cif");
            entity.Property(e => e.City)
                .HasMaxLength(250)
                .HasColumnName("city");
            entity.Property(e => e.Country)
                .HasMaxLength(250)
                .HasColumnName("country");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.FiscalName)
                .HasMaxLength(250)
                .HasColumnName("fiscalName");
            entity.Property(e => e.Insurance)
                .HasMaxLength(150)
                .HasColumnName("insurance");
            entity.Property(e => e.LastUpdate)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("datetime")
                .HasColumnName("last_update");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Risk)
                .HasPrecision(10)
                .HasColumnName("risk");
            entity.Property(e => e.State)
                .HasMaxLength(250)
                .HasColumnName("state");
            entity.Property(e => e.Status)
                .IsRequired()
                .HasDefaultValueSql("'1'")
                .HasColumnName("status");
            entity.Property(e => e.ZipCode)
                .HasMaxLength(250)
                .HasColumnName("zip_code");
        });

        modelBuilder.Entity<ProviderBankAccount>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("provider_bank_accounts");

            entity.HasIndex(e => e.IdProvider, "fk_pba_prov");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Iban)
                .HasMaxLength(34)
                .HasColumnName("iban");
            entity.Property(e => e.IdProvider)
                .HasColumnType("int(11)")
                .HasColumnName("id_provider");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.Status)
                .IsRequired()
                .HasDefaultValueSql("'1'")
                .HasColumnName("status");
        });

        modelBuilder.Entity<ProviderContact>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("provider_contacts");

            entity.HasIndex(e => e.IdProvider, "fk_contacts");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Department)
                .HasColumnType("enum('compras','it','logistica','administracion','comercial')")
                .HasColumnName("department");
            entity.Property(e => e.Email)
                .HasMaxLength(250)
                .HasColumnName("email");
            entity.Property(e => e.IdProvider)
                .HasColumnType("int(11)")
                .HasColumnName("id_provider");
            entity.Property(e => e.Name)
                .HasMaxLength(250)
                .HasColumnName("name");
            entity.Property(e => e.Phone)
                .HasMaxLength(50)
                .HasColumnName("phone");
            entity.Property(e => e.Phone2)
                .HasMaxLength(50)
                .HasColumnName("phone2");
        });

        modelBuilder.Entity<ProviderPaymentsMethod>(entity =>
        {
            entity.HasKey(e => new { e.IdProvider, e.IdPayment })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("provider_payments_methods");

            entity.HasIndex(e => e.IdPayment, "fk_id_payment");

            entity.Property(e => e.IdProvider)
                .HasColumnType("int(11)")
                .HasColumnName("id_provider");
            entity.Property(e => e.IdPayment)
                .HasColumnType("int(11)")
                .HasColumnName("id_payment");
        });

        modelBuilder.Entity<ProviderWarehouse>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("provider_warehouses");

            entity.HasIndex(e => e.IdProvider, "fk_id_provider_wh");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(250)
                .HasColumnName("address");
            entity.Property(e => e.City)
                .HasMaxLength(250)
                .HasColumnName("city");
            entity.Property(e => e.Country)
                .HasMaxLength(250)
                .HasColumnName("country");
            entity.Property(e => e.IdProvider)
                .HasColumnType("int(11)")
                .HasColumnName("id_provider");
            entity.Property(e => e.State)
                .HasMaxLength(250)
                .HasColumnName("state");
            entity.Property(e => e.Status)
                .IsRequired()
                .HasDefaultValueSql("'1'")
                .HasColumnName("status");
            entity.Property(e => e.ZipCode)
                .HasMaxLength(250)
                .HasColumnName("zip_code");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
