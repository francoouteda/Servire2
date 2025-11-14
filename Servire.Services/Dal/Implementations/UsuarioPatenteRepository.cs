using Servire.Services.Dal.Interfaces;
using Servire.Services.Domain.Composite;
using Servire.Services.Tools;
using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;

namespace Servire.Services.Dal.Implementations
{
    internal class UsuarioPatenteRepository : IJoinRepository<Patente, Usuario>
    {
        public List<Patente> GetByObject(Usuario obj)
        {
            List<Patente> patentes = new List<Patente>();
            string sql = "SELECT IdPatente FROM UsuarioPatente WHERE IdUsuario = @IdUsuario";

            using (SqlDataReader reader = SqlHelper.ExecuteReader(sql, CommandType.Text, new SqlParameter("@IdUsuario", obj.IdUsuario)))
            {
                while (reader.Read())
                {
                    Guid idPatente = reader.GetGuid(0); // Usa GetGuid
                    patentes.Add(new PatenteRepository().GetById(idPatente));
                }
            }
            return patentes;
        }
    }
}