using AutoMapper;
using CMSAppOA.Contract.DTOs;
using CMSAppOA.Contract.Services;
using CMSAppOA.Domain.Entities;
using CMSAppOA.Domain.Repository;
using Microsoft.Extensions.Logging;

namespace CMSAppOA.Application.Services;

public class OrderService : IOrderService
{
    private readonly IGenericRepository<Order> _repository;
    private readonly INotificationService _notificationService;
    private readonly ILogger<OrderService> _logger;
    private readonly IMapper _mapper;

    public OrderService(IGenericRepository<Order> repository, IMapper mapper, INotificationService notificationService, ILogger<OrderService> logger)
    {
        _repository = repository;
        _mapper = mapper;
        _notificationService = notificationService;
        _logger = logger;
    }

    public async Task AddAsync(OrderDto dto)
    {
        var entity = _mapper.Map<Order>(dto);
        var message = $"Adding new order for customer {entity.CustomerId} with total amount {entity.TotalAmount}";
        await _notificationService.SendEmailNotification(message, dto.CustomerId);
        var logMessage = $"Order added for customer {entity.CustomerId} with total amount {entity.TotalAmount}";
        _logger.LogInformation(logMessage);
        await _repository.AddAsync(entity);
    }

    public async Task DeleteAsync(int id)
    {
        await _repository.DeleteAsync(id);
    }

    public async Task<IEnumerable<OrderDto>> GetAllAsync()
    {
        var entities = await _repository.GetAllAsync();
        var dtos = _mapper.Map<IEnumerable<OrderDto>>(entities);
        return dtos;
    }

    public async Task<OrderDto> GetByIdAsync(int id)
    {
        var entity = await _repository.GetByIdAsync(id);
        if (entity == null)
        {
            return null;
        }
        var dto = _mapper.Map<OrderDto>(entity);
        return dto;
    }

    public async Task UpdateAsync(int id, OrderDto dto)
    {
        var entity = _mapper.Map<Order>(dto);
        await _repository.UpdateAsync(id, entity);
    }
}
