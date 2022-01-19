using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using XD.UI.Site.Data;

namespace XD.UI.Site
{
    public class Startup
    {

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<RazorViewEngineOptions>(options =>
            {
                options.AreaViewLocationFormats.Clear(); 
                options.AreaViewLocationFormats.Add("/Modulos/{2}/Views/{1}/{0}.cshtml"); 
                options.AreaViewLocationFormats.Add("/Modulos/{2}/Views/Shared/{0}.cshtml"); 
                options.AreaViewLocationFormats.Add("/Views/Shared/{0}.cshtml");

            });

            services.AddDbContext<MeuDbContext>(optionsAction: options =>
                options.UseSqlServer(Configuration.GetConnectionString("MeuDbContext")));

            services.AddControllersWithViews();

            services.AddTransient<IPedidoRepository, PedidoRepository>();
        }

        public void Configure(WebApplication app, IWebHostEnvironment environment)
        {
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapAreaControllerRoute("AreaProdutos", "Produtos", "Produtos/{controller=Cadastro}/{action=Index}/{id?}");

            app.MapAreaControllerRoute("AreaVendas", "Vendas", "Vendas/{controller=Pedidos}/{action=Index}/{id?}");

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
             
        }
    }
}