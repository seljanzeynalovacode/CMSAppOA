using CMSAppOA.Contract.DTOs;

namespace CMSAppOA.Contract.Services;

public interface IProductService
{
    Task<IEnumerable<ProductDto>> GetAllAsync();
    Task<ProductDto> GetByIdAsync(int id);
    Task AddAsync(ProductDto dto);
    Task UpdateAsync(int id, ProductDto dto);
    Task DeleteAsync(int id);
}
