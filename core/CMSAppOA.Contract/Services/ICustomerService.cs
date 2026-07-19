using CMSAppOA.Contract.DTOs;

namespace CMSAppOA.Contract.Services;

public interface ICustomerService
{
    Task<IEnumerable<CustomerDto>> GetAllAsync();
    Task<CustomerDto> GetByIdAsync(int id);
    Task AddAsync(CustomerDto dto);
    Task UpdateAsync(int id, CustomerDto dto);
    Task DeleteAsync(int id);
}
