using Servire.Services.Dal.Interfaces;
using Servire.Services.Domain.Composite;
using Servire.Services.Tools;
using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;

namespace Servire.Services.Dal.Implementations
{
    internal class UsuarioFamiliaRepository : IJoinRepository<Familia, Usuario>
    {
        public List<Familia> GetByObject(Usuario obj)
        {
            List<Familia> familias = new List<Familia>();
            string sql = "SELECT IdFamilia FROM UsuarioFamilia WHERE IdUsuario = @IdUsuario";

            using (SqlDataReader reader = SqlHelper.ExecuteReader(sql, CommandType.Text, new SqlParameter("@IdUsuario", obj.IdUsuario)))
            {
                while (reader.Read())
                {
                    Guid idFamilia = reader.GetGuid(0); // Usa GetGuid
                    familias.Add(new FamiliaRepository().GetById(idFamilia));
                }
            }
            return familias;
        }
    }
}