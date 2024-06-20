using AutoMapper;
using BusinessLogicLayer.Abstract;
using BusinessLogicLayer.Dtos;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Concrete
{
	public class ProductService(IProductRepository productRepository, IMapper mapper) : IProductService
	{
		private readonly IProductRepository _productRepository = productRepository;
		private readonly IMapper _mapper = mapper;

		public async Task AddProductAsync(ProductAddDto productAddDto)
		{
			if (productAddDto is null)
			{
				throw new Exception("Product can't be null");
			}
			var product = _mapper.Map<Product>(productAddDto);
			bool result = await _productRepository.AddAsync(product);
			if (result is false)
			{
				throw new Exception("Product can't add");
			}
			await _productRepository.SaveChangesAsync();
		}

        public async Task UpdateProduct(ProductAddDto productAddDto)
        {

			var product = await _productRepository.GetByIdAsync(productAddDto.Id);
            if (product != null)
            {
				try
				{
					product.Name = productAddDto.Name;
					product.Price = productAddDto.Price;
					product.CategoryId = productAddDto.CategoryId;
					product.BrandId = productAddDto.BrandId;
					product.Image = productAddDto.Image;
				}
				catch (Exception exc)
				{
					var message = exc.Message;
					throw;
				}
            }
            await _productRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<ProductViewDto>> GetAllProductsAsync()
		{
			var products = await _productRepository.GetProducts();
			return _mapper.Map<IEnumerable<ProductViewDto>>(products);
		}

        public async Task<ProductAddDto> GetByIdProductAsync(int Id)
        {
           var product = await _productRepository.GetByIdAsync(Id);
			return _mapper.Map<ProductAddDto>(product);
        }

        public async Task<ProductImageDto> GetProductImageAsync(int Id)
		{
			var products = await _productRepository.GetByIdAsync(Id);
			return _mapper.Map<ProductImageDto>(products);
		}
	}
}
