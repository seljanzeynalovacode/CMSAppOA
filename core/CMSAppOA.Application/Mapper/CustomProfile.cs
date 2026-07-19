using AutoMapper;
using CMSAppOA.Application.Services;
using CMSAppOA.Contract.DTOs;
using CMSAppOA.Domain.Entities;

namespace CMSAppOA.Application.Mapper;

public class CustomProfile : Profile
{
    public CustomProfile() 
    {
        CreateMap<Customer, CustomerDto>().ReverseMap();
        CreateMap<Product, ProductDto>().ReverseMap();
        CreateMap<Order, OrderDto>().ReverseMap();
        CreateMap<OrderItem, OrderItemDto>().ReverseMap();
    }
}
