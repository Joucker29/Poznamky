using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;

namespace Poznamky
{
    class Program
    {
        static void Main(string[] args)
        {
            // vytvoreni aplikace
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();
            var app = builder.Build();

            // nastaveni aplikace
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            // spusteni aplikace
            app.Run();
        }
    }
}