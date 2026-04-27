using CIT195HonorsProject.Data;
using Microsoft.EntityFrameworkCore;
namespace CIT195HonorsProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<CIT195HonorsProjectContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("CIT195HonorsProjectContext") ?? throw new InvalidOperationException("Connection string 'CIT195HonorsProjectContext' not found.")));

            // Add services to the container.
            builder.Services.AddRazorPages();

            var app = builder.Build();
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                // Calls the Initialize method using your Honors Project namespace
                CIT195HonorsProject.Models.SeedData.Initialize(services);
            }
            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapRazorPages()
               .WithStaticAssets();

            app.Run();
        }
    }
}
