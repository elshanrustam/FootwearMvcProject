using DataAccessLayer.Configurations.Common;
using EntityLayer.Concrete.Classes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Configurations.Classes;

public class CategoryConfig : BaseEntityConfig<Category>
{
    public override void Configure(EntityTypeBuilder<Category> builder)
    {
        base.Configure(builder);
        builder.Property(x => x.Name)
               .HasColumnType("nvarchar(50)");

        builder.HasData(
                         new Category { Id = 1, Name = "Men" },
                         new Category { Id = 2, Name = "Women" }
                       );
    }
}
