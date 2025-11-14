using Servire.Bll.Services;
using Servire.Domain.Entities;
using Servire.Domain.Entities.Seguridad;

namespace Servire.UI.Infrastructure
{
    public class UiSessionContext : ISessionContext
    {
        private static UiSessionContext? _instance;
        private Usuario? _usuarioLogueado;

        private UiSessionContext() { }

        public static UiSessionContext Instance
        {
            get
            {
                _instance ??= new UiSessionContext();
                return _instance;
            }
        }

        public void IniciarSesion(Usuario usuario)
        {
            _usuarioLogueado = usuario ?? throw new ArgumentNullException(nameof(usuario));
        }

        public void CerrarSesion()
        {
            _usuarioLogueado = null;
        }

        public string? Username => _usuarioLogueado?.Username;
        public bool EstaLogueado => _usuarioLogueado != null;


        public Usuario? Usuario => _usuarioLogueado;
       


        public bool TienePermiso(string patente)
        {
            if (!EstaLogueado || _usuarioLogueado == null) return false;

            return _usuarioLogueado.TienePermiso(patente);
        }
    }
}