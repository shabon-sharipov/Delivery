using Delivery.Application.Common.Interfaces;
using Delivery.Application.Common.Interfaces.Repositories;
using Delivery.Application.Mappers;
using Delivery.Application.Services;
using Delivery.Application.Validations.CreateCategoryCustomerRequestValidation;
using Delivery.Application.Validations.OrderValidations;
using Delivery.Application.Validations.ProductValidations;
using Delivery.Application.Validations.SenderValidations;
using Delivery.Infrastructure.Persistence.Database;
using Delivery.Infrastructure.Persistence.Repositories;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace Delivery.API
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

            //interfacec
            builder.Services.AddScoped<IProductService, ProductServices>();
            builder.Services.AddScoped<ICategoryProductServices, CategoryProductServices>();
            builder.Services.AddScoped<IMerchantCategoryService, MerchantCategoryService>();
            builder.Services.AddScoped<IDriverService, DriverService>();
            builder.Services.AddScoped<IOrderService, OrderService>();
            builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            builder.Services.AddScoped<IMerchantService, MerchantService>();

            //Validator
            builder.Services.AddFluentValidationAutoValidation();
            builder.Services.AddValidatorsFromAssembly(typeof(CreateProductValidation).Assembly);
            builder.Services.AddValidatorsFromAssembly(typeof(UpdateProductValidation).Assembly);
            builder.Services.AddValidatorsFromAssembly(typeof(CreateMerchantCategoryRequestValidation).Assembly);
            builder.Services.AddValidatorsFromAssembly(typeof(CreateDriverValidation).Assembly);
            builder.Services.AddValidatorsFromAssembly(typeof(UdateDriverValidation).Assembly);
            builder.Services.AddValidatorsFromAssembly(typeof(CreateOrderRequestValidation).Assembly);

            //AvtoMapper
            builder.Services.AddAutoMapper(typeof(AutoMapperConfiguration).Assembly);
           
            //Add Db
            builder.Services.AddDbContext<EFContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer"));
                options.UseLazyLoadingProxies();
            }, ServiceLifetime.Scoped);

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