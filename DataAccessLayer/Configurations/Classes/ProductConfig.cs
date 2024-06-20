using DataAccessLayer.Configurations.Common;
using EntityLayer.Concrete.Classes;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Configurations.Classes;

public class ProductConfig : BaseEntityConfig<Product>
{
    public override void Configure(EntityTypeBuilder<Product> builder)
    {
        base.Configure(builder);
        builder.HasOne(x => x.Brand)
               .WithMany(x => x.Products)
               .HasForeignKey(x => x.BrandId);
        builder.HasOne(p => p.Detail)
               .WithOne(d => d.Product)
               .HasForeignKey<Detail>(pd => pd.ProductId);

    }
}
