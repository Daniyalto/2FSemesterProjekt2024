using _2FSemesterProjekt2024.Models;
using _2FSemesterProjekt2024.Services.EF;
using _2FSemesterProjekt2024.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace _2FSemesterProjekt2024
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddDbContext<DriverDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Data Source=mssql3.unoeuro.com;Initial Catalog=jbased_dk_db_driver_db;User ID=jbased_dk;Password=********;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False")));

            builder.Services.AddTransient<IBookingService, EFBookingService>();
            builder.Services.AddTransient<IDriverService, EFDriverService>();
            builder.Services.AddTransient<IPassengerService, EFPassengerService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}
