using System;
using System.Collections.Generic;
using System.Linq;
// ¡Quitamos la dependencia a Servire.Services.Tools!
// La entidad ya no sabe cómo se hashea.

namespace Servire.Services.Domain.Composite
{
    public class Usuario
    {
        // --- Campos de Seguridad (de Services) ---
        public Guid IdUsuario { get; set; }
        public string Email { get; set; }

        // CORRECCIÓN 1: El setter ahora es público o 'internal'
        // para que el Repositorio y Servicio puedan asignarlo.
        public string PasswordHash { get; set; }

        public bool Habilitado { get; set; }

        // --- Campos de Negocio (de Domain.Entities) ---
        public string Username { get; set; }
        public string Nombre { get; set; }
        public string Dni { get; set; }
        public DateTime? UltimoAcceso { get; set; }
        public string? IdiomaPreferido { get; set; }
        public Rol Rol { get; set; }

        // --- Lógica de Composite (de Services) ---
        public List<PermisoComponente> Privilegios { get; set; }

        // Constructor vacío para Adapters
        public Usuario()
        {
            Nombre = string.Empty;
            Email = string.Empty;
            PasswordHash = string.Empty;
            Username = string.Empty;
            Dni = string.Empty;
            Privilegios = new List<PermisoComponente>();
        }

        // Constructor para leer de la BD (usado por el Adapter)
        // CORRECCIÓN 2: Ya no recibe 'passwordPlano', recibe el hash.
        public Usuario(Guid id, string username, string nombre, string email, string dni, string passwordHash, bool habilitado, Rol rol)
        {
            IdUsuario = id;
            Username = username;
            Nombre = nombre;
            Email = email;
            Dni = dni;
            PasswordHash = passwordHash; // Asignamos el hash directo
            Habilitado = habilitado;
            Rol = rol;
            Privilegios = new List<PermisoComponente>();
        }

        // CORRECCIÓN 3: ELIMINAMOS EL MÉTODO SetPassword(string passwordPlano)
        // Ya no es responsabilidad de esta clase.

        // --- Métodos de Permisos (Composite) ---
        public List<Patente> Patentes
        {
            get
            {
                var patentes = new List<Patente>();
                Recorrer(patentes, this.Privilegios);
                return patentes.Distinct().ToList();
            }
        }

        private void Recorrer(List<Patente> patentes, List<PermisoComponente> componentes)
        {
            if (componentes == null) return;
            foreach (var c in componentes)
            {
                if (c is Patente p)
                {
                    patentes.Add(p);
                }
                else if (c is Familia f)
                {
                    Recorrer(patentes, f.Hijos.ToList());
                }
            }
        }

        public bool TienePermiso(string permisoKey)
        {
            // 'Patentes' es la propiedad que ya aplana el árbol
            // 'Permiso' es la propiedad de la Patente que mapeamos del 'DataKey' del profe
            return Patentes.Any(p => p.Permiso.Equals(permisoKey, StringComparison.OrdinalIgnoreCase));
        }
    }
}