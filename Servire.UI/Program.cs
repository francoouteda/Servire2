using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Servire.Bll;
using Servire.Bll.Interfaces;
using Servire.Bll.Services;
using Servire.Dal.Ado;
using Servire.Services.Tools;
using Servire.UI.Forms;
using Servire.UI.Infrastructure;

namespace Servire.UI
{
    internal static class Program
    {
        public static IServiceProvider Services { get; private set; } = default!;

        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            var config = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            var connectionString = config.GetConnectionString("DefaultConnection");

            if (string.IsNullOrEmpty(connectionString))
            {
                MessageBox.Show("No se encontró 'DefaultConnection' en appsettings.json", "Error Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var services = new ServiceCollection();
            

          
            services.AddScoped<IStockService, StockService>();
            services.AddScoped<IProductoService, ProductoService>();


            services.AddTransient<frmLogin>();
            services.AddTransient<frmHome>();
            services.AddTransient<frmUsuarios>();
            services.AddTransient<frmBitacora>();
            services.AddTransient<frmUsuarioEdit>();
            services.AddTransient<ucStock>();
            services.AddTransient<ucProveedores>();
            services.AddTransient<frmProveedorEdit>();
            services.AddTransient<frmInsumoEdit>();
            services.AddTransient<ucProductos>();
            services.AddTransient<frmProductoEdit>();
            Services = services.BuildServiceProvider();
            var login = Services.GetRequiredService<frmLogin>();
            Application.Run(login);
        }
    }
}