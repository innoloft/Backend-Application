using Backend_Application.WebAPI.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Type = Backend_Application.WebAPI.Entities.Type;

namespace Backend_Application.WebAPI.Data
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public DbSet<Type> Types { get; set; }

        public DatabaseContext(DbContextOptions options):base (options)
        {

        }
    }
}
