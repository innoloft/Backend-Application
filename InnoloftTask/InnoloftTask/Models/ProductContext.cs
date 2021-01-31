using Microsoft.EntityFrameworkCore;
using Microsoft.Data.Sqlite;

namespace InnoloftTask.Models
{
    public class ProductContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite("Data Source=SqliteDB.db");
        }

        public DbSet<Product> Product { get; set; }
        public DbSet<Type> Type { get; set; }
    }
}
