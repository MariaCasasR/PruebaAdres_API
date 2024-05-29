using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PruebadevADRES_api.Models
{
    public partial class GestionAdresContext : DbContext
    {
        public GestionAdresContext()
        {
        }

        public GestionAdresContext(DbContextOptions<GestionAdresContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Proveedor> Proveedors { get; set; } = null!;
        public virtual DbSet<RequerimientosMed> RequerimientosMeds { get; set; } = null!;
        public virtual DbSet<Unidad> Unidads { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlite("Data Source=C:\\BD SQLITE\\GestionAdres.db;Cache=Shared");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Proveedor>(entity =>
            {
                entity.HasKey(e => e.IdProveedor);

                entity.ToTable("Proveedor");

                entity.Property(e => e.IdProveedor)
                    .HasColumnType("INT")
                    .ValueGeneratedNever();

                entity.Property(e => e.Nombre).HasColumnType("VARCHAR(50)");
            });

            modelBuilder.Entity<RequerimientosMed>(entity =>
            {
                entity.ToTable("RequerimientosMed");

                entity.Property(e => e.Id)
                    .HasColumnType("INT")
                    .ValueGeneratedNever();

                entity.Property(e => e.Cantidad).HasColumnType("INT");

                entity.Property(e => e.Documentacion).HasColumnType("VARCHAR(50)");

                entity.Property(e => e.FechaAd).HasColumnType("DATETIME");

                entity.Property(e => e.IdProveedor).HasColumnType("INT");

                entity.Property(e => e.IdUnidad).HasColumnType("INT");

                entity.Property(e => e.Presupuesto).HasColumnType("INT");

                entity.Property(e => e.Tipo).HasColumnType("VARCHAR(50)");

                entity.Property(e => e.ValorTotal).HasColumnType("INT");

                entity.Property(e => e.ValorUnitario).HasColumnType("INT");

                entity.HasOne(d => d.IdProveedorNavigation)
                    .WithMany(p => p.RequerimientosMeds)
                    .HasForeignKey(d => d.IdProveedor);

                entity.HasOne(d => d.IdUnidadNavigation)
                    .WithMany(p => p.RequerimientosMeds)
                    .HasForeignKey(d => d.IdUnidad);
            });

            modelBuilder.Entity<Unidad>(entity =>
            {
                entity.HasKey(e => e.IdUnidad);

                entity.ToTable("Unidad");

                entity.Property(e => e.IdUnidad)
                    .HasColumnType("INT")
                    .ValueGeneratedNever();

                entity.Property(e => e.Nombre).HasColumnType("VARCHAR(50)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
