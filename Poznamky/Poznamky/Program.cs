using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;

namespace Poznamky
{
    class Program
    {
        static void Main(string[] args)
        {
            // vytvoreni tvorice aplikace
            var builder = WebApplication.CreateBuilder(args);
            
            // nastaveni tvorice aplikace
            builder.Services.AddControllersWithViews();
            
            builder.Services.AddDbContext<Poznamky.Data.NasDatovyKontext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // vytvoreni aplikace
            var app = builder.Build();

            // nastaveni aplikace
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseSession();
            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(
                Path.Combine(Directory.GetCurrentDirectory(), "wwwroot"))
            });
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Vychozi}/{action=Index}/{id?}");

            // spusteni aplikace
            app.Run();
        }
    }
}