using BusinessLogicLayer.Dtos;
using EntityLayer.Concrete.Classes;

namespace BusinessLogicLayer.Abstract
{
    public interface IProductService
    {
        Task<IEnumerable<ProductViewDto>> GetAllProductsAsync();
     
        Task AddProductAsync(ProductAddDto productAddDto);

        Task<ProductImageDto> GetProductImageAsync(int Id);
        Task<ProductAddDto> GetByIdProductAsync(int Id);
        Task UpdateProduct(ProductAddDto productAddDto);
    }
}
