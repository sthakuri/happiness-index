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

    public virtual DbSet<Neighborhood> Neighborhoods { get; set; }

    public virtual DbSet<Population> Populations { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
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

        modelBuilder.Entity<Population>(entity =>
        {
            entity.HasKey(e => e.PopulationId).HasName("PK__tmp_ms_x__3A2E15C20DF47D0C");

            entity.ToTable("Population");

            entity.Property(e => e.PopulationId).HasColumnName("PopulationID");
            entity.Property(e => e.NeighborhoodId).HasColumnName("NeighborhoodID");

            entity.HasOne(d => d.Neighborhood).WithMany(p => p.Populations)
                .HasForeignKey(d => d.NeighborhoodId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Population_NeighborhoodID");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
