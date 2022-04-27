using Microsoft.EntityFrameworkCore;
using Comercio.Models;
using MySQL.Data.EntityFrameworkCore;

namespace Comercio.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }  = null!;
        public DbSet<Produto> Produtos { get; set; }  = null!;
        public DbSet<Carrinho> Carrinhos { get; set; }  = null!;
        public DbSet<Compra> Compras { get; set; } = null!;
        protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlite("DataSource=app.db;Cache=shared");
        
        
        
        //protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseMySQL("server=localhost;database=db;user=root;password=password123");   
     
  

    }
}