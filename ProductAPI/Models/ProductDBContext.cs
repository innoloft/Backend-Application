namespace ProductAPI.Models
{
    using Microsoft.EntityFrameworkCore;

    public class ProductDBContext: DbContext
    {
        public ProductDBContext(DbContextOptions<ProductDBContext> options): base(options)
        {
        }

        public DbSet<Product> Products
        {
            get;
            set;
        }

        public DbSet<User> Users
        {
            get;
            set;
        }

        public DbSet<Address> Addresses
        {
            get;
            set;
        }

        public DbSet<Company> Companies
        {
            get;
            set;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                        .HasMany(u => u.products)
                        .WithOne(p => p.owner);

            modelBuilder.Entity<User>()
                        .HasOne(u => u.address)
                        .WithOne(a => a.user)
                        .HasForeignKey<Address>(a => a.userId);

            modelBuilder.Entity<User>()
                        .HasOne(u => u.company)
                        .WithMany(c => c.users);
            
            modelBuilder.Entity<Product>()
                        .Property(p => p.type)
                        .HasConversion<int>();

            Company company = new Company {
                            id = 1,
                            name = "Romaguera-Crona",
                            catchPhrase = "Multi-layered client-server neural-net",
                            bs = "harness real-time e-markets"
                        };
            
            modelBuilder.Entity<Company>()
                        .HasData(company);

            modelBuilder.Entity<User>()
                        .HasData(new User {
                            id = 1,
                            name = "Leanne Graham",
                            username = "Brett",
                            password = "pass@123",
                            email = "Sincere@april.biz",
                            phone = "1-770-736-8031 x56442",
                            website = "hildegard.org",
                            companyId = 1
                        });

            modelBuilder.Entity<Address>()
                        .HasData(new Address() {
                                id = 1,
                                street = "Kulas Light",
                                suite = "Apt. 556",
                                city = "Gwenborough",
                                zipcode = "92998-3874",
                                latitude = "-37.3159",
                                longitude = "81.1496",
                                userId = 1
                            });
            
            modelBuilder.Entity<User>()
                        .HasData(new User {
                            id = 2,
                            name = "Kwabena Gray",
                            username = "Gray",
                            password = "pass@123",
                            email = "Sincere1@april.biz",
                            phone = "1-770-736-8031 x56442",
                            website = "hildegard.org",
                            companyId = 1
                        });

            modelBuilder.Entity<Address>()
                        .HasData(new Address() {
                                id = 2,
                                street = "Coach and Horses Street",
                                suite = "Apt. 556",
                                city = "Portsmouth",
                                zipcode = "92998-3874",
                                latitude = "-37.3159",
                                longitude = "81.1496",
                                userId = 2
                            });
            
            modelBuilder.Entity<Product>()
                        .HasData(new Product() {
                            id = 1,
                            name = "Home Energy Management Solution",
                            description = "The solution is meant to optimize energy consumption",
                            type = ProductType.Software,
                            ownerId = 1
                        });
        
            modelBuilder.Entity<Product>()
                        .HasData(new Product() {
                            id = 2,
                            name = "Smart Lamps",
                            description = "The Lamps are developed by market leading organization",
                            type = ProductType.Hardware,
                            ownerId = 2
                        });

            base.OnModelCreating(modelBuilder);
        }
    }
}