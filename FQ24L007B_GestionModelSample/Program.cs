using DE = FQ24L007B_GestionModelSample.Dal.Entities;
using DR = FQ24L007B_GestionModelSample.Dal.Repositories;
using DS = FQ24L007B_GestionModelSample.Dal.Services;

using FQ24L007B_GestionModelSample.Bll.Entities;
using FQ24L007B_GestionModelSample.Bll.Repositories;
using FQ24L007B_GestionModelSample.Bll.Services;

using System.Data.Common;
using Microsoft.Data.SqlClient;

namespace FQ24L007B_GestionModelSample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            IConfiguration configuration = builder.Configuration;
            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped<DbConnection>(sp => new SqlConnection(configuration.GetConnectionString("default")));
            builder.Services.AddScoped<DR.ISampleRepository, DS.SampleService>();
            builder.Services.AddScoped<ISampleRepository, SampleService>();

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
