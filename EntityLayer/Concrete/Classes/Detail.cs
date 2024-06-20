using EntityLayer.Concrete.Common;

namespace EntityLayer.Concrete.Classes;

public class Detail : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string Image { get; set; } = string.Empty;
    public double Price { get; set; }
    public int ProductId { get; set; }
    public Product Product { get; set; }
}
