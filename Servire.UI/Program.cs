using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Servire.Bll.Interfaces; // Para IPasswordHasher
using Servire.Bll.Services;
using Servire.Dal.Ado;
using Servire.Services.Dal.Implementations; // Para UsuarioRepository
using Servire.Services.Dal.Interfaces; // Para IUsuarioRepository
using Servire.Services.Implementations; // Para LoggerService
using Servire.Services.Interfaces; // Para ILogger
using Servire.Services.Tools;
using Servire.UI.Forms;
using Servire.UI.Infrastructure;

namespace Servire.UI
{
    internal static class Program
    {
        public static IServiceProvider Services { get; private set; } = default!;

        // Esta propiedad estática es un anti-patrón, pero la usaremos
        // para mantener tu lógica de 'Program.CurrentUser'
        public static Servire.Services.Domain.Composite.Usuario? CurrentUser { get; set; }


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

            // --- REGISTRO DE DEPENDENCIAS ---
            // Registramos la BLL y DAL
            services.AddScoped<IUnitOfWork>(provider => new UnitOfWorkAdo(connectionString));
            services.AddScoped<IStockService, StockService>();
            services.AddScoped<IProductoService, ProductoService>();

            // REGISTRAMOS LOS SERVICIOS DE SEGURIDAD Y LOGGING QUE FALTABAN
            services.AddSingleton<IPasswordHasher, PasswordHasher>();
            services.AddSingleton<ILogger, LoggerService>();

            // Registramos los repositorios de 'Services'
            // OJO: Tu capa Services usa SqlHelper (estático) y no DI, 
            // así que registramos el repositorio concreto.
            services.AddSingleton<IUsuarioRepository, UsuarioRepository>();

            // Registramos la Sesión (aunque tu UiSessionContext es un Singleton estático, lo cual es otro anti-patrón)
            services.AddSingleton<ISessionContext>(UiSessionContext.Instance);

            // Registramos los formularios
            services.AddTransient<frmLogin>();
            services.AddTransient<frmHome>();
            services.AddTransient<frmUsuarios>();
            services.AddTransient<frmBitacora>();
            services.AddTransient<frmUsuarioEdit>(); // Ya no lo usas con DI, pero lo dejamos
            services.AddTransient<ucStock>();
            services.AddTransient<ucProveedores>();
            services.AddTransient<frmProveedorEdit>();
            services.AddTransient<frmInsumoEdit>();
            services.AddTransient<ucProductos>();
            services.AddTransient<frmProductoEdit>();

            Services = services.BuildServiceProvider();

            // --- FLUJO DE INICIO CORRECTO ---
            using (var loginForm = Services.GetRequiredService<frmLogin>())
            {
                // Mostramos el login como un diálogo
                if (loginForm.ShowDialog() == DialogResult.OK)
                {
                    var homeForm = Services.GetRequiredService<frmHome>();
                    homeForm.UsuarioLogueado = CurrentUser; // Le pasamos el usuario
                    Application.Run(homeForm);
                }
                else
                {
                    // Si el usuario cierra el login, salimos de la app
                    Application.Exit();
                }
            }
        }
    }
}