using CMSAppOA.Contract.DTOs;
using CMSAppOA.Contract.Services;
using CMSAppOA.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CMSAppOA.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemsController : ControllerBase
    {
        private readonly IOrderItemService _service;
        public OrderItemsController(IOrderItemService doctorService)
        {
            _service = doctorService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var doctors = await _service.GetAllAsync();
            return Ok(doctors);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var doctor = await _service.GetByIdAsync(id);
            if (doctor == null)
                return NotFound();
            return Ok(doctor);
        }
        [HttpPost]
        public async Task<IActionResult> Add(OrderItemDto dto)
        {
            await _service.AddAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = dto.Id }, dto);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, OrderItemDto dto)
        {
            await _service.UpdateAsync(id, dto);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
