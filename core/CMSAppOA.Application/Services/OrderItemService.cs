using AutoMapper;
using CMSAppOA.Contract.DTOs;
using CMSAppOA.Contract.Services;
using CMSAppOA.Domain.Entities;
using CMSAppOA.Domain.Repository;

namespace CMSAppOA.Application.Services;

public class OrderItemService : IOrderItemService
{
    private readonly IGenericRepository<OrderItem> _repository;
    private readonly IMapper _mapper;

    public OrderItemService(IGenericRepository<OrderItem> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task AddAsync(OrderItemDto dto)
    {
        var entity = _mapper.Map<OrderItem>(dto);
        await _repository.AddAsync(entity);
    }

    public async Task DeleteAsync(int id)
    {
        await _repository.DeleteAsync(id);
    }

    public async Task<IEnumerable<OrderItemDto>> GetAllAsync()
    {
        var entities = await _repository.GetAllAsync();
        var dtos = _mapper.Map<IEnumerable<OrderItemDto>>(entities);
        return dtos;
    }

    public async Task<OrderItemDto> GetByIdAsync(int id)
    {
        var entity = await _repository.GetByIdAsync(id);
        if (entity == null)
        {
            return null;
        }
        var dto = _mapper.Map<OrderItemDto>(entity);
        return dto;
    }

    public async Task UpdateAsync(int id, OrderItemDto dto)
    {
        var entity = _mapper.Map<OrderItem>(dto);
        await _repository.UpdateAsync(id, entity);
    }
}
