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
    public class CategoryService(ICategoryRepository categoryRepository, IMapper mapper) : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository = categoryRepository;
        private readonly IMapper _mapper = mapper;
        public async Task<IEnumerable<CategoryViewDto>> GetAllCategoriesAsync()
        {
            var categories = await _categoryRepository.GetAllAsync(false);
            return _mapper.Map<IEnumerable<CategoryViewDto>>(categories);
        }
    }
}
