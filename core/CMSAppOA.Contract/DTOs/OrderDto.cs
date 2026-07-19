namespace CMSAppOA.Contract.DTOs;

public record OrderDto : BaseDto
{
    public int CustomerId { get; set; }
    public DateTime OrderDate { get; set; }
    public decimal TotalAmount { get; set; }
    public List<OrderItemDto> OrderItems { get; set; } = new List<OrderItemDto>();
}
