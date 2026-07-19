namespace CMSAppOA.Domain.Entities;

public class Product : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Price { get; set; }
    public int StockQuantity { get; set; }
}
