using EntityLayer.Concrete.Classes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Configurations.Classes;

public class ProductOrderConfig : IEntityTypeConfiguration<ProductOrder>
{
    public void Configure(EntityTypeBuilder<ProductOrder> builder)
    {
        builder.HasKey(x => new { x.ProductId, x.OrderId });
        builder.HasOne(x => x.Order)
               .WithMany(x => x.ProductOrders)
               .HasForeignKey(x => x.OrderId);
        builder.HasOne(x => x.Product)
               .WithMany(x => x.ProductOrders)
               .HasForeignKey(x => x.ProductId);
    }
}
