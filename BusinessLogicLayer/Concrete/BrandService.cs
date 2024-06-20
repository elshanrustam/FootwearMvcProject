using AutoMapper;
using BusinessLogicLayer.Abstract;
using BusinessLogicLayer.Dtos;
using DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Concrete
{
    public class BrandService(IBrandRepository brandRepository,IMapper mapper) : IBrandService
    {
        private readonly IBrandRepository _brandRepository = brandRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<IEnumerable<BrandViewDto>> GetBrandViewDtos()
        {
            var brands = await _brandRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<BrandViewDto>>(brands);
        }
    }
}
