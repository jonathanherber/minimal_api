using Microsoft.EntityFrameworkCore;
using Comercio.Models;
namespace Comercio.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Clients> Client { get; set; }
        public DbSet<Products> Product { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlite("DataSource=app.db;Cache=shared");
    }
}