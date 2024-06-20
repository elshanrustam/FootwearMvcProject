using DataAccessLayer.Configurations.Common;
using EntityLayer.Concrete.Classes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.Configurations.Classes;

public class CustomerConfig : BaseEntityConfig<Customer>
{
    public override void Configure(EntityTypeBuilder<Customer> builder)
    {
        base.Configure(builder);
        builder.Property(x => x.FirstName)
              .HasColumnType("nvarchar(30)")
              .IsRequired();
        builder.Property(x => x.LastName)
             .HasColumnType("nvarchar(70)");

    }
}
