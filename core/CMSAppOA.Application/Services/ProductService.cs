using AutoMapper;
using CMSAppOA.Contract.DTOs;
using CMSAppOA.Contract.Services;
using CMSAppOA.Domain.Entities;
using CMSAppOA.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSAppOA.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IGenericRepository<Product> _repository;
        private readonly IMapper _mapper;

        public ProductService(IGenericRepository<Product> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task AddAsync(ProductDto dto)
        {
            var entity = _mapper.Map<Product>(dto);
            await _repository.AddAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<ProductDto>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            var dtos = _mapper.Map<IEnumerable<ProductDto>>(entities);
            return dtos;
        }

        public async Task<ProductDto> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
            {
                return null;
            }
            var dto = _mapper.Map<ProductDto>(entity);
            return dto;
        }

        public async Task UpdateAsync(int id, ProductDto dto)
        {
            var entity = _mapper.Map<Product>(dto);
            await _repository.UpdateAsync(id, entity);
        }
    }

}
