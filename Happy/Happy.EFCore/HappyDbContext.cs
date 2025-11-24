using System;
using System.Collections.Generic;
using Happy.EFCore.Models;
using Microsoft.EntityFrameworkCore;

namespace Happy.EFCore;

public partial class HappyDbContext : DbContext
{
    public HappyDbContext()
    {
    }

    public HappyDbContext(DbContextOptions<HappyDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Crime> Crimes { get; set; }

    public virtual DbSet<Income> Incomes { get; set; }

    public virtual DbSet<Neighborhood> Neighborhoods { get; set; }

    public virtual DbSet<ParkAndFacility> ParkAndFacilities { get; set; }

    public virtual DbSet<Population> Populations { get; set; }

    public virtual DbSet<Rental> Rentals { get; set; }

    public virtual DbSet<Transportation> Transportations { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Crime>(entity =>
        {
            entity.HasKey(e => e.CrimeId).HasName("PK__Crime__83ED048D989A1220");

            entity.ToTable("Crime");

            entity.Property(e => e.CrimeId).HasColumnName("CrimeID");
            entity.Property(e => e.NeighborhoodId).HasColumnName("NeighborhoodID");
            entity.Property(e => e.Score).HasColumnType("decimal(2, 1)");

            entity.HasOne(d => d.Neighborhood).WithMany(p => p.Crimes)
                .HasForeignKey(d => d.NeighborhoodId)
                .HasConstraintName("FK_Crime_NeighborhoodID");
        });

        modelBuilder.Entity<Income>(entity =>
        {
            entity.HasKey(e => e.IncomeId).HasName("PK__Income__60DFC66CF5F04735");

            entity.ToTable("Income");

            entity.Property(e => e.IncomeId).HasColumnName("IncomeID");
            entity.Property(e => e.NeighborhoodId).HasColumnName("NeighborhoodID");
            entity.Property(e => e.Score).HasColumnType("decimal(2, 1)");

            entity.HasOne(d => d.Neighborhood).WithMany(p => p.Incomes)
                .HasForeignKey(d => d.NeighborhoodId)
                .HasConstraintName("FK_Income_NeighborhoodID");
        });

        modelBuilder.Entity<Neighborhood>(entity =>
        {
            entity.HasKey(e => e.NeighborhoodId).HasName("PK__Neighbor__268014493C6A3D65");

            entity.ToTable("Neighborhood");

            entity.HasIndex(e => e.ZipCode, "IX_Neighborhood_ZipCode");

            entity.HasIndex(e => new { e.NeighborhoodName, e.ZipCode }, "UQ_NeighborhoodName_ZipCode").IsUnique();

            entity.Property(e => e.NeighborhoodId).HasColumnName("NeighborhoodID");
            entity.Property(e => e.NeighborhoodName).HasMaxLength(50);
            entity.Property(e => e.ZipCode)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ParkAndFacility>(entity =>
        {
            entity.HasKey(e => e.ParkAndFacilityId).HasName("PK__ParkAndF__1DE20C17942DDF01");

            entity.ToTable("ParkAndFacility");

            entity.Property(e => e.ParkAndFacilityId).HasColumnName("ParkAndFacilityID");
            entity.Property(e => e.NeighborhoodId).HasColumnName("NeighborhoodID");
            entity.Property(e => e.Score).HasColumnType("decimal(2, 1)");

            entity.HasOne(d => d.Neighborhood).WithMany(p => p.ParkAndFacilities)
                .HasForeignKey(d => d.NeighborhoodId)
                .HasConstraintName("FK_ParkAndFacility_NeighborhoodID");
        });

        modelBuilder.Entity<Population>(entity =>
        {
            entity.HasKey(e => e.PopulationId).HasName("PK__tmp_ms_x__3A2E15C20DF47D0C");

            entity.ToTable("Population");

            entity.Property(e => e.PopulationId).HasColumnName("PopulationID");
            entity.Property(e => e.NeighborhoodId).HasColumnName("NeighborhoodID");

            entity.HasOne(d => d.Neighborhood).WithMany(p => p.Populations)
                .HasForeignKey(d => d.NeighborhoodId)
                .HasConstraintName("FK_Population_NeighborhoodID");
        });

        modelBuilder.Entity<Rental>(entity =>
        {
            entity.HasKey(e => e.RentalId).HasName("PK__Rental__9700596399B44E69");

            entity.ToTable("Rental");

            entity.Property(e => e.RentalId).HasColumnName("RentalID");
            entity.Property(e => e.NeighborhoodId).HasColumnName("NeighborhoodID");
            entity.Property(e => e.Score).HasColumnType("decimal(2, 1)");

            entity.HasOne(d => d.Neighborhood).WithMany(p => p.Rentals)
                .HasForeignKey(d => d.NeighborhoodId)
                .HasConstraintName("FK_Rental_NeighborhoodID");
        });

        modelBuilder.Entity<Transportation>(entity =>
        {
            entity.HasKey(e => e.TransportationId).HasName("PK__Transpor__87E47956A7ED2435");

            entity.ToTable("Transportation");

            entity.Property(e => e.TransportationId).HasColumnName("TransportationID");
            entity.Property(e => e.NeighborhoodId).HasColumnName("NeighborhoodID");
            entity.Property(e => e.Score).HasColumnType("decimal(2, 1)");

            entity.HasOne(d => d.Neighborhood).WithMany(p => p.Transportations)
                .HasForeignKey(d => d.NeighborhoodId)
                .HasConstraintName("FK_Transportation_NeighborhoodID");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
