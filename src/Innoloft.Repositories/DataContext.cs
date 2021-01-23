using Microsoft.EntityFrameworkCore;
using Innoloft.Interfaces.Entities;

namespace Innoloft.Repositories
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Person>()
            .HasKey(x => x.Id);

            modelBuilder.Entity<Product>()
            .HasKey(x => x.Id);

            modelBuilder.Entity<Product>()
            .Property(x => x.Title).HasMaxLength(200);

            modelBuilder.Entity<Product>()
            .Property(x => x.Description).HasMaxLength(2000);

            modelBuilder.Entity<Product>()
               .HasOne(x => x.ProductType)
               .WithMany(x => x.Products)
               .HasForeignKey(x => x.ProductTypeId)
               .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<Product>()
                .HasOne(x => x.ContactPerson)
                .WithMany(x => x.Products)
                .HasForeignKey(x => x.PersonId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ProductType>()
            .HasKey(x => x.Id);

        }
    }
}
