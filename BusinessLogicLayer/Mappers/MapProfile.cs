using AutoMapper;
using BusinessLogicLayer.Dtos;
using EntityLayer.Concrete.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Mappers
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Product, ProductViewDto>()
                .ForMember(s => s.Category, x => x.MapFrom(y => y.Category.Name))
                .ForMember(a => a.Brand, b => b.MapFrom(c => c.Brand.Name));

            CreateMap<Product, ProductImageDto>();

            CreateMap<Product, ProductAddDto>().ReverseMap();

            CreateMap<Category, CategoryViewDto>();

            CreateMap<Brand, BrandViewDto>();
        }
    }
}
