using System;
using System.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace DAL.Entities
{
    public partial class innoloftContext : DbContext
    {
        public innoloftContext(DbContextOptions<innoloftContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Contactperson> Contactperson { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Type> Type { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("server=localhost;port=3306;user=root;password=abcd@1234;database=innoloft");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contactperson>(entity =>
            {
                entity.ToTable("contactperson");

                entity.HasIndex(e => e.Id)
                    .HasName("Id_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Name).HasColumnType("varchar(100)");

                entity.Property(e => e.Phone).HasColumnType("varchar(100)");

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("product");

                entity.HasIndex(e => e.Id)
                    .HasName("Id_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasColumnType("longtext");

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Type>(entity =>
            {
                entity.ToTable("type");

                entity.HasIndex(e => e.Id)
                    .HasName("Id_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Name).HasColumnType("varchar(100)");

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });
        }
    }
}
