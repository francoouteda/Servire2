using Servire.Bll.Interfaces;
using Servire.Domain.Entities;

namespace Servire.Bll.Services
{
    public class BitacoraService : IBitacoraService
    {
        private readonly IUnitOfWork _uow;

        // Depende de la abstracción IUnitOfWork, no de SQL o EF
        public BitacoraService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public void Registrar(string username, string accion, string mensaje)
        {
            // Lógica de negocio (ej: validaciones)
            if (string.IsNullOrWhiteSpace(username)) username = "(sistema)";
            if (accion.Length > 50) throw new Exception("Acción demasiado larga");

            // Creación de la entidad
            var log = new Bitacora
            {
                Fecha = DateTime.Now,
                Username = username,
                Accion = accion,
                Mensaje = mensaje
            };

            // Delega el guardado al repositorio
            _uow.BitacoraRepository.Registrar(log);

            // ¡IMPORTANTE! Este servicio NO hace Commit.
            // El servicio que Inicia la operación (ej: UsuarioService.Crear)
            // es quien debe hacer el Commit al final.
        }

        public IEnumerable<Bitacora> Listar(DateTime desde, DateTime hasta)
        {
            // Simplemente delega la lectura
            return _uow.BitacoraRepository.Listar(desde, hasta);
        }
    }
}