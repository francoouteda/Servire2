using System;
using System.Collections.Generic;
using Servire.Services.Dal.Interfaces;
using Servire.Services.Dal.Implementations;
using Servire.Services.Domain.Composite;

namespace Servire.Services.Dal.Implementations.Adapters
{
    internal sealed class UsuarioAdapter : IAdapter<Usuario>
    {
        #region Singleton
        private readonly static UsuarioAdapter _instance = new UsuarioAdapter();
        public static UsuarioAdapter Current => _instance;
        private UsuarioAdapter() { }
        #endregion

        public Usuario Get(object[] values)
        {
            // Orden del SQL (10 campos):
            // [0]IdUsuario, [1]Username, [2]Nombre, [3]Email, [4]Dni, 
            // [5]PasswordHash, [6]Habilitado, [7]Rol, [8]UltimoAcceso, [9]IdiomaPreferido

            var usuario = new Usuario(
                id: Guid.Parse(values[0].ToString()),
                username: values[1].ToString(),
                nombre: values[2].ToString(),
                email: values[3].ToString(),
                dni: values[4].ToString(),
                passwordHash: values[5].ToString(),
                habilitado: bool.Parse(values[6].ToString()),
                rol: (Rol)Enum.Parse(typeof(Rol), values[7].ToString())
            );

            // Asignamos los campos que pueden ser nulos
            usuario.UltimoAcceso = values[8] == DBNull.Value ? null : (DateTime?)values[8];
            usuario.IdiomaPreferido = values[9] == DBNull.Value ? null : values[9].ToString();

            // Lógica para llenar los permisos (esto sigue igual)
            var repoFamilia = new UsuarioFamiliaRepository();
            usuario.Privilegios.AddRange(repoFamilia.GetByObject(usuario));

            var repoPatente = new UsuarioPatenteRepository();
            usuario.Privilegios.AddRange(repoPatente.GetByObject(usuario));

            return usuario;
        }
    }
}