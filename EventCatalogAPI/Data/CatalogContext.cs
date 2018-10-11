using EventCatalogAPI.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventCatalogAPI.Data
{
    public class CatalogContext : DbContext
    {
        public CatalogContext(DbContextOptions options)
            : base(options)
        {

        }
    public DbSet<CatalogType> CatalogTypes { get; set; }

    public DbSet<CatalogDate> CatalogDates { get; set; }

    public DbSet<CatalogLocation> CatalogLocations { get; set; }

    public DbSet<CatalogEvent> CatalogEvents { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CatalogType>(ConfigureCatalogType);
            modelBuilder.Entity<CatalogDate>(ConfigureCatalogDate);
            modelBuilder.Entity<CatalogLocation>(ConfigureCatalogLocation);
            modelBuilder.Entity<CatalogEvent>(ConfigureCatalogEvent);
        }

        private void ConfigureCatalogType(
               EntityTypeBuilder<CatalogType> builder)
        {
            builder.ToTable("CatalogType");
            builder.Property(c => c.Id)
                .IsRequired()
                .ForSqlServerUseSequenceHiLo("catalog_type_hilo");
            builder.Property(c => c.Type)
                .IsRequired()
                .HasMaxLength(100);

        }

        private void ConfigureCatalogDate(
                EntityTypeBuilder<CatalogDate> builder)
        {
            builder.ToTable("CatalogDate");
            builder.Property(c => c.Id)
                .IsRequired()
                .ForSqlServerUseSequenceHiLo("catalog_date_hilo");
            builder.Property(c => c.Date)
                .IsRequired();
        }

        private void ConfigureCatalogLocation(
               EntityTypeBuilder<CatalogLocation> builder)
        {
            builder.ToTable("CatalogLocation");
            builder.Property(c => c.Id)
                .IsRequired()
                .ForSqlServerUseSequenceHiLo("catalog_location_hilo");
            builder.Property(c => c.Location)
                .IsRequired()
                .HasMaxLength(100);
        }

        private void ConfigureCatalogEvent(
      EntityTypeBuilder<CatalogEvent> builder)
        {
            builder.ToTable("Catalog");
            builder.Property(c => c.Id)
                .IsRequired()
                .ForSqlServerUseSequenceHiLo("catalog_hilo");
            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(c => c.Fee)
                .IsRequired();
            builder.HasOne(c => c.CatalogType)
                .WithMany()
                .HasForeignKey(c => c.CatalogTypeId);
            builder.HasOne(c => c.CatalogDate)
                .WithMany()
                .HasForeignKey(c => c.CatalogDateId);
            builder.HasOne(c => c.CatalogLocation)
                .WithMany()
                .HasForeignKey(c => c.CatalogLocationId);
        }



    }
}
