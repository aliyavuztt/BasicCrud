using BasicCrud.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BasicCrud.DataAccess.Concrete.EntityFramework.Mappings
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();

            builder.Property(a => a.Name).IsRequired();
            builder.Property(a => a.Name).HasMaxLength(50);

            builder.Property(a => a.Stock).IsRequired();

            builder.Property(a => a.Price).IsRequired();
            builder.Property(a => a.Price).HasColumnType("decimal(18,2)");

            builder.ToTable("Products");
        }
    }
}