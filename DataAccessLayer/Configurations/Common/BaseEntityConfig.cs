using EntityLayer.Concrete.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.Configurations.Common;

public class BaseEntityConfig<T> : IEntityTypeConfiguration<T> where T : BaseEntity, new()
{
    public virtual void Configure(EntityTypeBuilder<T> builder)
    {
        builder.HasKey(x => x.Id);
    }
}
