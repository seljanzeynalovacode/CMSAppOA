using CMSAppOA.Domain.Entities;
using CMSAppOA.Persistance.Configurations;
using Microsoft.EntityFrameworkCore;


namespace CMSAppOA.Persistance.Data;

public  class CMSAppDbContext : DbContext
{
    public CMSAppDbContext(DbContextOptions<CMSAppDbContext> options) : base(options)
    {
    }

    public DbSet<Customer> Customers { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new OrderConfiguration());
        modelBuilder.ApplyConfiguration(new OrderItemConfiguration());
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CMSAppDbContext).Assembly);
    }
}
