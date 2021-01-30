using BackendApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace BackendApplication.Context
{
    public class ApplicationContext: DbContext
    {
        public DbSet<Product> Products { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options): base(options)
        {
            Database.EnsureCreated();
        }
    }
}
