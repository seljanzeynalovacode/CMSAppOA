namespace CMSAppOA.Contract.DTOs;

public record ProductDto : BaseDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Price { get; set; }
    public int StockQuantity { get; set; }
}
