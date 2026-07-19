using CMSAppOA.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CMSAppOA.Persistance.Configurations;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.Property(o => o.CustomerId).IsRequired();
        builder.Property(o => o.OrderDate).IsRequired();
        builder.Property(o => o.TotalAmount).HasColumnType("decimal(18,2)").IsRequired();
        builder.HasMany(o => o.OrderItems)
               .WithOne(oi => oi.Order)
               .HasForeignKey(oi => oi.OrderId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}