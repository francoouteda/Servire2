using Servire.Domain.Entities;

namespace Servire.Bll.Services;

public interface ISessionContext
{
    string? Username { get; }
    Usuario? Usuario { get; }
    bool EstaLogueado { get; }
    void IniciarSesion(Usuario usuario);
    void CerrarSesion();
    bool TienePermiso(string patente);

}
