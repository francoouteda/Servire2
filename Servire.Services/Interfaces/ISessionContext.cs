using Servire.Domain.Entities;
using Servire.Services.Domain.Composite;

namespace Servire.Services.Interfaces;

public interface ISessionContext
{
    string? Username { get; }
    Usuario? Usuario { get; }
    bool EstaLogueado { get; }
    void IniciarSesion(Usuario usuario);
    void CerrarSesion();
    bool TienePermiso(string patente);

}
