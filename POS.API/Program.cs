using MediatR;
using Microsoft.EntityFrameworkCore;
using POS.Application.Repositories;
using POS.Infrastructure.Data;
using POS.Infrastructure.Repositories;
using POS.Infrastructure.Handlers;

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
            builder.Services.AddSwaggerGen();

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
