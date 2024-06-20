using EntityLayer.Concrete.Common;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityLayer.Concrete.Classes;

public class Product : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public double Price { get; set; }
    public string Image { get; set; } = string.Empty;
    public bool IsDeactive { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; }
    public int BrandId { get; set; }
    public Brand Brand { get; set; }
    public Detail Detail { get; set; }
    [NotMapped]
    public IFormFile Photo { get; set; }
    public ICollection<ProductOrder> ProductOrders { get; set; }
}
