using Servire.Bll.Interfaces;
using Servire.Domain.Entities;
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
        private readonly IErrorLogger _log;

        public UsuarioService(
            IUnitOfWork uow,
            IPasswordHasher hasher,
            IBitacoraService bitacora,
            ISessionContext session,
            IErrorLogger log)
        {
            _uow = uow;
            _hasher = hasher;
            _bitacora = bitacora;
            _session = session;
            _log = log;
        }

        public Usuario Login(string username, string password)
        {
            try
            {
                // --- INICIO DE DIAGNÓSTICO ---
                var u = _uow.UsuarioRepository.ObtenerPorUsername(username);

                if (u == null)
                {
                    // Si el usuario es nulo, lo logueamos y fallamos.
                    _log.Error(nameof(UsuarioService) + ".Login-DIAGNOSTICO", new  Exception($"Usuario '{username}' NO encontrado en la base de datos."), username);
                    throw new Exception("Credenciales inválidas.");
                }

                // Si llegamos aquí, el usuario SÍ existe.
                // Logueamos los datos que encontramos.
                _log.Info(nameof(UsuarioService) + ".Login-DIAGNOSTICO", $"Usuario '{username}' ENCONTRADO. Activo: {u.Activo}, Hash en BD: {u.PasswordHash}", username);

                // --- FIN DE DIAGNÓSTICO ---

                // La lógica de negocio pura
                if (!u.Activo) throw new Exception("Credenciales inválidas."); // Falla si no está activo
                if (!_hasher.Verify(password, u.PasswordHash)) throw new Exception("Credenciales inválidas."); // Falla si el hash no coincide

                // Si llegamos aquí, el login fue exitoso
                u.UltimoAcceso = DateTime.Now;
                _uow.UsuarioRepository.Actualizar(u);
                _bitacora.Registrar(u.Username, "Login", "Acceso correcto");
                _uow.Commit();
                return u;
            }
            catch (Exception ex)
            {
                // Logueamos la excepción REAL (sea la nuestra o una de SQL)
                _log.Error(nameof(UsuarioService) + ".Login-CATCH", ex, username);

                _bitacora.Registrar(username, "Login", "Acceso fallido");

                try { _uow.Commit(); } catch { /* Ignorar error de commit de bitácora */ }

                throw new Exception("Credenciales inválidas.");
            }
        }

        // ... (El resto de tu clase UsuarioService.cs no necesita cambios)
        // ... (Crear, Actualizar, Listar, etc.)
        #region Otros Metodos
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

        public void Actualizar(Usuario u)
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

        public void CambiarPassword(int userId, string nuevoPassword)
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

        public void ToggleActivo(int userId, bool activo)
        {
            var u = _uow.UsuarioRepository.ObtenerPorId(userId);
            if (u == null) throw new Exception("Usuario no encontrado.");

            u.Activo = activo;

            _uow.UsuarioRepository.Actualizar(u);
            _bitacora.Registrar(UsuarioActual(), activo ? "Activar Usuario" : "Desactivar Usuario", $"Usuario: {u.Username}");

            _uow.Commit();
        }

        public void Validar(Usuario u)
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
        #endregion
    }
}