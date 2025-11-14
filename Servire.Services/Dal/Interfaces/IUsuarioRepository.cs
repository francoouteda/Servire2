using Servire.Services.Domain.Composite;
using System;
using System.Collections.Generic;

namespace Servire.Services.Dal.Interfaces
{
    // Esta interfaz define TODO lo que la BLL necesita saber sobre los usuarios
    public interface IUsuarioRepository
    {
        // Métodos de Lectura
        Usuario GetByCredentials(string username, string passwordHash);
        Usuario ObtenerPorId(Guid id);
        Usuario ObtenerPorUsername(string username);
        IEnumerable<Usuario> Listar();

        // Métodos de Escritura
        void RegistrarUsuario(Usuario usuario);
        void Actualizar(Usuario usuario);

        // Métodos de Validación
        bool ExisteUsername(string username, Guid? excludeId = null);
        bool ExisteDni(string dni, Guid? excludeId = null);
    }
}