using AssetManagement.Api.Dependencies;
using AssetManagement.Application.Abstractions;
using AssetManagement.Application.Models.Assets.Queries;
using AssetManagement.Application.Generics;
using AssetManagement.Persistence;
using AssetManagement.Persistence.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace AssetManagement.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddApplicationServices();
            builder.Services.RegisterQueryHandler();

            //add database data context connection
            builder.Services.AddDbContextPool<AssetManagementDBContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("Default"), b => b.MigrationsAssembly("AssetManagement.Persistence")));

            builder.Services.AddCors(opt =>
            {
                opt.AddPolicy("CorsPolicy", policy =>
                {
                    policy.AllowAnyMethod().AllowAnyHeader().WithOrigins("http://localhost:4200");
                });
            });

            //TODO: Move to Dependencies folder
            builder.Services.AddScoped<AssetManagementDBContext>();
            builder.Services.AddTransient<IAssetRepository, AssetRepository>();


            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

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