
using CMSAppOA.Contract.DTOs;

namespace CMSAppOA.Contract.Services;

public interface IOrderService
{
    Task<IEnumerable<OrderDto>> GetAllAsync();
    Task<OrderDto> GetByIdAsync(int id);
    Task AddAsync(OrderDto dto);
    Task UpdateAsync(int id, OrderDto dto);
    Task DeleteAsync(int id);
}
