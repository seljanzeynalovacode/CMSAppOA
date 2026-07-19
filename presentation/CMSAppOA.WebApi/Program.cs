
using CMSAppOA.Application.Mapper;
using CMSAppOA.Application.Services;
using CMSAppOA.Contract.Services;
using CMSAppOA.Domain.Repository;
using CMSAppOA.Persistance.Data;
using CMSAppOA.Persistance.Repository;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace CMSAppOA.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // serilog
            Log.Logger = new LoggerConfiguration()
               .ReadFrom.Configuration(builder.Configuration)
               .Enrich.FromLogContext()
               .CreateLogger();
            

            builder.Host.UseSerilog();
            


            builder.Services.AddDbContext<CMSAppDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString")));

            builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            builder.Services.AddAutoMapper(x => x.AddProfile(typeof(CustomProfile)));

            builder.Services.AddScoped<ICustomerService, CustomerService>();
            builder.Services.AddScoped<IProductService, ProductService>();
            builder.Services.AddScoped<IOrderService, OrderService>();
            builder.Services.AddScoped<IOrderItemService, OrderItemService>();
            builder.Services.AddScoped<INotificationService, NotificationService>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
