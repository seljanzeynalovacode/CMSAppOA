using AutoMapper;
using CMSAppOA.Contract.DTOs;
using CMSAppOA.Contract.Services;
using CMSAppOA.Domain.Entities;
using CMSAppOA.Domain.Repository;

namespace CMSAppOA.Application.Services;

public class CustomerService : ICustomerService
{
    private readonly IGenericRepository<Customer> _repository;
    private readonly IMapper _mapper;

    public CustomerService(IGenericRepository<Customer> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task AddAsync(CustomerDto dto)
    {
        var entity = _mapper.Map<Customer>(dto);
        await _repository.AddAsync(entity);
    }

    public async Task DeleteAsync(int id)
    {
        await _repository.DeleteAsync(id);
    }

    public async Task<IEnumerable<CustomerDto>> GetAllAsync()
    {
        var entities = await _repository.GetAllAsync();
        var dtos = _mapper.Map<IEnumerable<CustomerDto>>(entities);
        return dtos;
    }

    public async Task<CustomerDto> GetByIdAsync(int id)
    {
        var entity = await _repository.GetByIdAsync(id);
        if (entity == null)
        {
            return null;
        }
        var dto = _mapper.Map<CustomerDto>(entity);
        return dto;
    }

    public async Task UpdateAsync(int id, CustomerDto dto)
    {
        var entity = _mapper.Map<Customer>(dto);
        await _repository.UpdateAsync(id, entity);
    }
}
