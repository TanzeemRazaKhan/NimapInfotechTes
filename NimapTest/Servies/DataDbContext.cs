using Microsoft.EntityFrameworkCore;
using NimapTest.Models;
using System.Xml;

namespace NimapTest.Servies
{
    public class DataDbContext : DbContext
    {

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }


        // Constructor with DbContextOptions
        public DataDbContext(DbContextOptions options) : base(options)
        {
        }

     
    }
}
