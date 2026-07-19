namespace CMSAppOA.Domain.Entities;

public class Order : BaseEntity
{
    public int CustomerId { get; set; }
    public Customer Customer { get; set; }
    public DateTime OrderDate { get; set; }
    public decimal TotalAmount { get; set; }
    public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}
