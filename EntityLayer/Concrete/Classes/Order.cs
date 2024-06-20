using EntityLayer.Concrete.Common;

namespace EntityLayer.Concrete.Classes;

public class Order : BaseEntity
{
    public int OrderNumber { get; set; }
    public double TotalPrice { get; set; }
    public int CustomerId { get; set; }
    public Customer Customer { get; set; }
    public ICollection<ProductOrder> ProductOrders { get; set; }
}
