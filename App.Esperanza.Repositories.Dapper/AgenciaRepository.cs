using App.Esperanza.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Esperanza.Repositories.Dapper
{
    public class AgenciaRepository : Repository<Agencia>, IAgenciaRepository
    {
        public AgenciaRepository(string connectionString) : base(connectionString)
        {
        }

        public async Task<int> Eliminar(int id) //soft delete
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@id", id);
                return await connection.ExecuteAsync("update Agencia " +
                                                     "set Estado = 0 " +
                                                     "where Id = @id", parameters,
                                                     commandType: System.Data.CommandType.Text);
            }
        }
    }
}
