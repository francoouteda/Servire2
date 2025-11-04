using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Servire.Bll;
using Servire.Bll.Interfaces;        // <- Para IUnitOfWork, IBitacoraService, IUsuarioService, etc.
using Servire.Bll.Services;          // <- Para BitacoraService, UsuarioService
                                     // <- Para IPasswordHasher, PasswordHasher
using Servire.Dal.Ado;             // <- Para UnitOfWorkAdo
using Servire.Services;            // <- Para ErrorLogger
using Servire.UI.Forms;
using Servire.UI.Infrastructure;   // <- Para UiSessionContext
using System;
using System.Windows.Forms;

namespace Servire.UI
{
    internal static class Program
    {
        public static IServiceProvider Services { get; private set; } = default!;
        public static Servire.Domain.Entities.Usuario? CurrentUser { get; set; }

        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            var config = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            // --- INICIO DE CORRECCIONES ---

            // 1. Obtén la cadena de conexión
            var connectionString = config.GetConnectionString("DefaultConnection");

            // 1b. Valida que la cadena de conexión exista
            if (string.IsNullOrEmpty(connectionString))
            {
                MessageBox.Show("No se encontró 'DefaultConnection' en appsettings.json", "Error Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var services = new ServiceCollection();

            // 2. Registra el Unit of Work (ADO.NET)
            //    Aquí estaba tu error: 'connectionString' no estaba definido.
            services.AddScoped<IUnitOfWork>(sp => new UnitOfWorkAdo(connectionString));

            // 3. Registra los Servicios de BLL (que dependen de IUnitOfWork)
            services.AddScoped<IBitacoraService, BitacoraService>();
            services.AddScoped<IErrorLogService, ErrorLogService>();
            services.AddScoped<IUsuarioService, UsuarioService>();

            services.AddScoped<IErrorLogger>(sp =>
     new ErrorLogger(config));
 
            // 4. Registra los Servicios de Infraestructura
             services.AddSingleton<ISessionContext, UiSessionContext>();
           
            services.AddScoped<IPasswordHasher, PasswordHasher>(); // <- Faltaba este

            // 5. Registra los Formularios
            services.AddTransient<frmLogin>();
            services.AddTransient<frmHome>();
            services.AddTransient<frmUsuarios>();
            services.AddTransient<frmBitacora>();

            // 6. SERVICIOS ANTIGUOS (ELIMINADOS)
            //    Estamos reemplazando EF Core (ServireContext) con el UnitOfWork (ADO.NET)
            //    Por lo tanto, ya no registramos el DbContext.
            //
            // services.AddDbContext<ServireContext>(opt => ...);  // <-- ELIMINADO
            // services.AddScoped<IAuditoriaQueries, AuditoriaQueries>(); // <-- ELIMINADO (era de EF)

            // --- FIN DE CORRECCIONES ---

            Services = services.BuildServiceProvider();

            var login = Services.GetRequiredService<frmLogin>();
            Application.Run(login);
        }
    }
}