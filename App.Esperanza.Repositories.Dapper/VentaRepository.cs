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

        public async Task<IEnumerable<Venta>> ListarPorCliente(int idCliente)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@idCliente", idCliente);
                return await connection.QueryAsync<Venta>("dbo.UspListarVentasPorCliente", parameters,
                                            commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<Venta>> ListarPorUsuario(int ventaIdAsesor)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@idUsuario", ventaIdAsesor);
                return await connection.QueryAsync<Venta>("dbo.UspListarVentasPorUsuario", parameters,
                                            commandType: System.Data.CommandType.StoredProcedure);
            }
        }
    }
}
