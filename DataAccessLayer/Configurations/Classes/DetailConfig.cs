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
    public class DetailConfig  : BaseEntityConfig<Detail>
    {
        public override void Configure(EntityTypeBuilder<Detail> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.Name)
                   .HasColumnType("nvarchar(50)")
                   .IsRequired();
        }
    }
}
