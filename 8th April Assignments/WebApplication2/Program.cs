using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;

namespace WebApplication2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

           // builder.Configuration.AddAzureAppConfiguration("Endpoint=https://people.azconfig.io;Id=/f2B;Secret=FQFTgzUTnjRK8DqJHK0uUPzqM7KFbHLHcKaPr4hOESBC3UdQtdvXJQQJ99CDACqBBLy4lRDVAAABAZACTGp3");
           // var dbPassword = builder.Configuration["Common:Settings:dbpassword"];

            // 3. Build the full connection string using that password
            var connectionString =
                $"Server=tcp:chitreshsqlcg.database.windows.net,1433;" +
                $"Initial Catalog=CHITRESHDB;" +
                $"Persist Security Info=False;" +
                $"User ID=Chitresh;" +
                $"Password=Bhumii123456@;" +
                $"MultipleActiveResultSets=False;" +
                $"Encrypt=True;" +
                $"TrustServerCertificate=False;" +
                $"Connection Timeout=30;";


           // var connectionString = builder.Configuration.GetConnectionString("AzureSqlConnection"); // here in appsetting u have to give this value //okay from statement 2 okay 
            builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));


            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();
/*
            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            */

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
