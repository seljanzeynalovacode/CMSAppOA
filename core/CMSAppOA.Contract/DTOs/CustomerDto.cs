namespace CMSAppOA.Contract.DTOs;

public record CustomerDto : BaseDto
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }
}
