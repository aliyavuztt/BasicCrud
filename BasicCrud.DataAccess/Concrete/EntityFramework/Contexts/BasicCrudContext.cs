using BasicCrud.DataAccess.Concrete.EntityFramework.Mappings;
using BasicCrud.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace BasicCrud.DataAccess.Concrete.EntityFramework.Contexts
{
    public class BasicCrudContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(@"Server=localhost;Database=BasicCrud;User Id=postgres;Password=12345;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductMap());
        }
    }
}