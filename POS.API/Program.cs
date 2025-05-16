using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using POS.Application.Repositories;
using POS.Infrastructure.Data;
using POS.Infrastructure.Handlers;
using POS.Infrastructure.Repositories;

namespace POS.API
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
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "POS API",
                    Version = "v1",
                    Description = "API documentation for POS system"
                });

                // Resolve schemaId conflicts by using the full name with namespaces
                options.CustomSchemaIds(type =>
                {
                    if (type.DeclaringType != null)
                    {
                        return $"{type.DeclaringType.Name}.{type.Name}";
                    }
                    return type.Name;
                });
            });


            builder.Services.AddDbContext<PosDBContext>((serviceProvider, dbContextOptionsBuilder) =>
            {
                var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

                dbContextOptionsBuilder.UseSqlServer(connectionString, sqlOptions =>
                {
                    sqlOptions.EnableRetryOnFailure(
                        maxRetryCount: 5,
                        maxRetryDelay: TimeSpan.FromSeconds(10),
                        errorNumbersToAdd: null
                    );

                    sqlOptions.CommandTimeout(30); // Command timeout in seconds
                });

                dbContextOptionsBuilder.EnableDetailedErrors(true);
                dbContextOptionsBuilder.EnableSensitiveDataLogging(true);
            });


            builder.Services.AddScoped<IProductRepository,  ProductRepository>();
            builder.Services.AddScoped<IAccountRepository,  AccountRepository>();

            builder.Services.AddMediatR(typeof(CreateProductHandler).Assembly);

            builder.Services.AddMediatR(typeof(CreateAccountHandler).Assembly);
            builder.Services.AddMediatR(typeof(GetAccountByUsernameHandler).Assembly);




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
