using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductModuleDataAccess.Models
{
    public class ProducrModuleDbContext : DbContext
    {
        public ProducrModuleDbContext(DbContextOptions<ProducrModuleDbContext> options) : base(options)
        {
        }

        public DbSet<Types> types { get; set; }

        public DbSet<Contacts> contacts { get; set; }

        public DbSet<Products> products { get; set; }       
    }
}
