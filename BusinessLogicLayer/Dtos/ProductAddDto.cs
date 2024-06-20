using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Dtos
{
    public class ProductAddDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public double Price { get; set; }
        public int CategoryId { get; set; }
        public int BrandId { get; set; }
        public bool IsDeactive { get; set; }    
        public string Image { get; set; } = string.Empty;

        [NotMapped]
        public IFormFile Photo { get; set; }
    }
}
