
using Catalog.Application.Queries;
using Catalog.Core.Repositories;
using Catalog.Infrastructure.Data.Contexts;
using Catalog.Infrastructure.Data.Repositories;
using System.Reflection;

namespace Catalog.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            // u have to register the assembly by only passing a query or command that is in the assembly u want to register
            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(
                Assembly.GetExecutingAssembly(),
                Assembly.GetAssembly(typeof(GetProductByIdQuery))));

            // make it singleton because if it is scoped, the object will not be created until sending a request
            // not creating an object, means not checking if there is data seeded yet or not
            builder.Services.AddSingleton<ICatalogContext, CatalogContext>();

            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddScoped<IProductBrandRepository, ProductBrandRepository>();
            builder.Services.AddScoped<IProductTypeRepository, ProductTypeRepository>();

            builder.Services.AddApiVersioning(options =>
            {
                options.ReportApiVersions = true;
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new Asp.Versioning.ApiVersion(1, 0);
            });

            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddSwaggerGen((options) =>
            {
                options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "Catalog API",
                    Version = "v1",
                    Description = "Catalog API microservice for e-commerce application",
                    Contact = new Microsoft.OpenApi.Models.OpenApiContact
                    {
                        Name = "Eslam Khalifa",
                        Email = "eslam.w.khalifa@gmail.com",
                        Url = new Uri("https://www.linkedin.com/in/eslam-khalifa-40a421237")
                    }
                });
            });

            builder.Services.AddOpenApi();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
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
