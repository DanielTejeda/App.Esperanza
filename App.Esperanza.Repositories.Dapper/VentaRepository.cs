using App.Esperanza.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace App.Esperanza.Repositories.Dapper
{
    public class VentaRepository : Repository<Venta>, IVentaRepository
    {
        public VentaRepository(string connectionString) : base(connectionString)
        {
        }

        public async Task<IEnumerable<Venta>> ListaPendientes()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                //var parameters = new DynamicParameters();
                //parameters.Add("@username", username);
                //verificar tema del timeout
                return await connection.QueryAsync<Venta>("dbo.UspListarVentasPendientes", null,
                                            commandType: System.Data.CommandType.StoredProcedure);
            }
        }
    }
}
