using CleanArchMvc.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchMvc.Infra.Data.EntitiesConfiguration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(c => c.Name).HasMaxLength(100).IsRequired();
            builder.Property(c => c.Description).HasMaxLength(200).IsRequired();
            builder.Property(c => c.Price).HasPrecision(10, 2).IsRequired();

            builder
                .HasOne(p => p.Category)
                .WithMany(p => p.Products)
                .HasForeignKey(p => p.CategoryId);
        }
    }
}
