using DataAccessLayer.Configurations.Common;
using EntityLayer.Concrete.Classes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Configurations.Classes
{
    public class BrandConfig : BaseEntityConfig<Brand>
    {
        public override void Configure(EntityTypeBuilder<Brand> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.Name)
                   .HasColumnType("nvarchar(50)")
                   .IsRequired();

            builder.HasData(
                              new Brand { Id = 1, Name = "Nike" },
                              new Brand { Id = 2, Name = "Adidas" },
                              new Brand { Id = 3, Name = "Gucci" }
                           );
        }
    }
}
