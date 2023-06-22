using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectAPI.Domain.Entities;

namespace ProjectAPI.Infra.Data.Mapping
{
    public class StoreMapping : IEntityTypeConfiguration<Store>
    {
        public void Configure(EntityTypeBuilder<Store> builder)
        {
            builder.HasKey(s => s.Id);

            builder.Property(s => s.Name)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(s => s.Address)
                .IsRequired()
                .HasColumnType("varchar(255)");

            builder.ToTable("Store");
        }
    }
}
