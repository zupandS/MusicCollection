using Microsoft.EntityFrameworkCore;
using MusicCollection.DAL;
using MusicCollection.Service.Interfaces;
using MusicCollection.Service.Implimentations;
using MusicCollection.DAL.Interfaces;
using MusicCollection.Domain.Entity;
using MusicCollection.DAL.Repositories;
using Microsoft.Extensions.Configuration;

namespace MusicCollection
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var configurationbuilder = new ConfigurationBuilder();
            configurationbuilder.SetBasePath(Directory.GetCurrentDirectory());
            configurationbuilder.AddJsonFile("appsettings.json");
            var config = configurationbuilder.Build();

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<ApplicationContext>(options => options.UseNpgsql(config.GetConnectionString("DefaultConnection")));
            builder.Services.AddScoped<IMusicRepository<Music>, MusicRepository>();
            builder.Services.AddScoped<IMusicService, MusicService>();

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