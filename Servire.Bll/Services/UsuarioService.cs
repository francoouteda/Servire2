using Servire.Bll.Interfaces;
using Servire.Domain.Entities;
using Servire.Domain.Entities.Seguridad;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Servire.Bll.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUnitOfWork _uow;
        private readonly IPasswordHasher _hasher;
        private readonly IBitacoraService _bitacora;
        private readonly ISessionContext _session;

        // Se eliminó IErrorLogger del constructor
        public UsuarioService(
            IUnitOfWork uow,
            IPasswordHasher hasher,
            IBitacoraService bitacora,
            ISessionContext session)
        {
            _uow = uow;
            _hasher = hasher;
            _bitacora = bitacora;
            _session = session;
        }

        public Usuario Login(string username, string password)
        {
            // Sin try/catch gigante solo para loguear. 
            // Solo nos protegemos para transacciones o dejamos que fluya.
            // Al ser lectura, incluso podríamos prescindir de la transacción si no auditamos login.
            // Pero como auditamos (Bitacora) y actualizamos fecha, la necesitamos.

            _uow.BeginTransaction();
            try
            {
                var u = _uow.UsuarioRepository.ObtenerPorUsername(username);

                // Validaciones de negocio
                if (u == null || !u.Activo || !_hasher.Verify(password, u.PasswordHash))
                {
                    // Bitacora de intento fallido
                    _bitacora.Registrar(username, "Login", "Acceso fallido (Credenciales inválidas)");
                    _uow.Commit(); // Guardamos el intento fallido en bitácora
                    throw new Exception("Credenciales inválidas.");
                }

                // Éxito
                u.UltimoAcceso = DateTime.Now;
                _uow.UsuarioRepository.Actualizar(u);
                _bitacora.Registrar(u.Username, "Login", "Acceso correcto");

                // TODO: Refactorizar CargarPermisos (ver punto siguiente)
                CargarPermisos(u);

                _uow.Commit();
                return u;
            }
            catch (Exception)
            {
                // Solo hacemos Rollback si algo falló a nivel de BD inesperadamente
                try { _uow.Rollback(); } catch { }
                throw; // Re-lanzamos la excepción para que la capa Services/UI la loguee
            }
        }

        public IEnumerable<Usuario> Listar()
        {
            return _uow.UsuarioRepository.Listar();
        }

        public Usuario? ObtenerPorId(int id)
        {
            return _uow.UsuarioRepository.ObtenerPorId(id);
        }

        public void Crear(Usuario u, string passwordPlano)
        {
            _uow.BeginTransaction();
            try
            {
                Validar(u);
                if (string.IsNullOrWhiteSpace(passwordPlano) || passwordPlano.Length < 8)
                    throw new Exception("La contraseña es requerida y debe tener al menos 8 caracteres.");

                if (_uow.UsuarioRepository.ExisteUsername(u.Username))
                    throw new Exception("El nombre de usuario ya existe.");

                if (_uow.UsuarioRepository.ExisteDni(u.Dni))
                    throw new Exception("El DNI ya existe.");

                u.PasswordHash = _hasher.Hash(passwordPlano);
                if (u.UltimoAcceso == default) u.UltimoAcceso = DateTime.Now;

                _uow.UsuarioRepository.Crear(u);
                _bitacora.Registrar(UsuarioActual(), "Alta Usuario", $"Usuario: {u.Username}");

                _uow.Commit();
            }
            catch (Exception)
            {
                try { _uow.Rollback(); } catch { }
                throw;
            }
        }

        public void Actualizar(Usuario u)
        {
            _uow.BeginTransaction();
            try
            {
                Validar(u);

                if (_uow.UsuarioRepository.ExisteUsername(u.Username, u.Id))
                    throw new Exception("El nombre de usuario ya existe.");

                if (_uow.UsuarioRepository.ExisteDni(u.Dni, u.Id))
                    throw new Exception("El DNI ya existe.");

                var dbu = _uow.UsuarioRepository.ObtenerPorId(u.Id);
                if (dbu == null) throw new Exception("Usuario no encontrado.");

                dbu.Username = u.Username;
                dbu.Nombre = u.Nombre;
                dbu.Dni = u.Dni;
                dbu.Rol = u.Rol;
                dbu.Activo = u.Activo;

                _uow.UsuarioRepository.Actualizar(dbu);
                _bitacora.Registrar(UsuarioActual(), "Edición Usuario", $"Usuario: {u.Username}");

                _uow.Commit();
            }
            catch (Exception)
            {
                try { _uow.Rollback(); } catch { }
                throw;
            }
        }

        public void CambiarPassword(int userId, string nuevoPassword)
        {
            _uow.BeginTransaction();
            try
            {
                if (string.IsNullOrWhiteSpace(nuevoPassword) || nuevoPassword.Length < 8)
                    throw new Exception("La contraseña nueva debe tener al menos 8 caracteres.");

                var u = _uow.UsuarioRepository.ObtenerPorId(userId);
                if (u == null) throw new Exception("Usuario no encontrado.");

                u.PasswordHash = _hasher.Hash(nuevoPassword);

                _uow.UsuarioRepository.Actualizar(u);
                _bitacora.Registrar(UsuarioActual(), "Cambio Password", $"Usuario: {u.Username}");

                _uow.Commit();
            }
            catch (Exception)
            {
                try { _uow.Rollback(); } catch { }
                throw;
            }
        }

        public void ToggleActivo(int userId, bool activo)
        {
            _uow.BeginTransaction();
            try
            {
                var u = _uow.UsuarioRepository.ObtenerPorId(userId);
                if (u == null) throw new Exception("Usuario no encontrado.");

                u.Activo = activo;

                _uow.UsuarioRepository.Actualizar(u);
                _bitacora.Registrar(UsuarioActual(), activo ? "Activar Usuario" : "Desactivar Usuario", $"Usuario: {u.Username}");

                _uow.Commit();
            }
            catch (Exception)
            {
                try { _uow.Rollback(); } catch { }
                throw;
            }
        }

        public void GuardarIdiomaPreferido(int usuarioId, string codigoCultura)
        {
            _uow.BeginTransaction();
            try
            {
                var usuario = _uow.UsuarioRepository.ObtenerPorId(usuarioId);
                if (usuario == null) throw new Exception("Usuario no encontrado.");

                usuario.IdiomaPreferido = codigoCultura;

                _uow.UsuarioRepository.Actualizar(usuario);
                _bitacora.Registrar(usuario.Username, "Cambio Idioma", $"Nuevo idioma: {codigoCultura}");
                _uow.Commit();

                if (_session.Usuario != null)
                {
                    _session.Usuario.IdiomaPreferido = codigoCultura;
                }
            }
            catch (Exception)
            {
                try { _uow.Rollback(); } catch { }
                throw;
            }
        }

        private void Validar(Usuario u)
        {
            if (u == null) throw new ArgumentNullException(nameof(u));
            if (string.IsNullOrWhiteSpace(u.Username)) throw new Exception("El nombre de usuario es requerido.");
            if (u.Username.Length < 4) throw new Exception("El nombre de usuario debe tener al menos 4 caracteres.");

            if (string.IsNullOrWhiteSpace(u.Nombre)) throw new Exception("El nombre es requerido.");

            var dni = (u.Dni ?? "").Trim();
            if (dni.Length < 7 || dni.Length > 10 || !dni.All(char.IsDigit))
                throw new Exception("DNI inválido. Debe ser numérico y tener entre 7 y 10 dígitos.");
        }

        private string UsuarioActual() => _session.Username ?? "(sistema)";

        private void CargarPermisos(Usuario u)
        {
            // ESTO SIGUE PENDIENTE DE REFACTORIZAR PARA NO USAR NEW()
            // Pero por ahora lo dejamos igual para que compile sin tocar lógica profunda
            var pAccesoAdmin = new Patente { Nombre = "Acceso_Admin" };
            var pGestionUsuarios = new Patente { Nombre = "Gestion_Usuarios" };
            var pAccesoBitacora = new Patente { Nombre = "Acceso_Bitacora" };
            var pTomarPedidos = new Patente { Nombre = "Tomar_Pedidos" };
            var pVerComandas = new Patente { Nombre = "Ver_Comandas" };
            var pGestionStock = new Patente { Nombre = "Gestion_Stock" };

            var fAdmin = new Familia { Nombre = "Admin" };
            fAdmin.Agregar(pAccesoAdmin);
            fAdmin.Agregar(pGestionUsuarios);
            fAdmin.Agregar(pAccesoBitacora);
            fAdmin.Agregar(pGestionStock);

            var fMozo = new Familia { Nombre = "Mozo" };
            fMozo.Agregar(pTomarPedidos);

            var fCocina = new Familia { Nombre = "Cocina" };
            fCocina.Agregar(pVerComandas);

            var fBarra = new Familia { Nombre = "Barra" };
            fBarra.Agregar(pVerComandas);

            u.Permisos.Clear();

            switch (u.Rol)
            {
                case Rol.Admin:
                    u.Permisos.Add(fAdmin);
                    break;
                case Rol.Mozo:
                    u.Permisos.Add(fMozo);
                    break;
                case Rol.Cocina:
                    u.Permisos.Add(fCocina);
                    break;
                case Rol.Barra:
                    u.Permisos.Add(fBarra);
                    break;
            }
        }
    }
}