using CMSAppOA.Contract.DTOs;

namespace CMSAppOA.Contract.Services;

public interface IOrderItemService
{
    Task<IEnumerable<OrderItemDto>> GetAllAsync();
    Task<OrderItemDto> GetByIdAsync(int id);
    Task AddAsync(OrderItemDto dto);
    Task UpdateAsync(int id, OrderItemDto dto);
    Task DeleteAsync(int id);
}
