using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectAPI.Domain.Entities;

namespace ProjectAPI.Infra.Data.Mapping
{
    public class StockItemMapping : IEntityTypeConfiguration<StockItem>
    {
        public void Configure(EntityTypeBuilder<StockItem> builder)
        {
            builder.HasKey(st => st.Id);

            builder.Property(st => st.ProductId)
                .IsRequired();

            builder.Property(st => st.StoreId)
                .IsRequired();

            builder.Property(st => st.Quantity)
                .IsRequired();

            builder.Property(st => st.CostPriceProduct)
                .IsRequired();

            // 1 : 0...1 => Product: StockItem
            builder.HasOne(p => p.Product)
                .WithOne()
                .HasForeignKey<StockItem>(st => st.ProductId)
                .IsRequired(false);

            // 1 : 0...1 => Store: StockItem
            builder.HasOne(s => s.Store)
                .WithOne()
                .HasForeignKey<StockItem>(st => st.StoreId)
                .IsRequired(false);

            builder.ToTable("StockItem");
        }
    }
}
