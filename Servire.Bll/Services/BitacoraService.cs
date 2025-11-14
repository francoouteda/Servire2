using Servire.Bll.Interfaces;
using Servire.Domain.Entities;

namespace Servire.Bll.Services
{
    public class BitacoraService : IBitacoraService
    {
        private readonly IUnitOfWork _uow;
        public BitacoraService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public void Registrar(string username, string accion, string mensaje)
        {
           
            if (string.IsNullOrWhiteSpace(username)) username = "(sistema)";
            if (accion.Length > 50) throw new Exception("Acción demasiado larga");

            
            var log = new Bitacora
            {
                Fecha = DateTime.Now,
                Username = username,
                Accion = accion,
                Mensaje = mensaje
            };

            _uow.BitacoraRepository.Registrar(log);

        }
        public IUnitOfWork GetUoW()
        {
            return _uow;
        }
        public IEnumerable<Bitacora> Listar(DateTime desde, DateTime hasta)
        {
            return _uow.BitacoraRepository.Listar(desde, hasta);
        }
    }
}