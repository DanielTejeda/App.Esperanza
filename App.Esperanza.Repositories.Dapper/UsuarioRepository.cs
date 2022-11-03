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
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(string connectionString) : base(connectionString)
        {
        }

        public async Task<int> Eliminar(int id) //soft delete
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@id", id);
                return await connection.ExecuteAsync("update Usuario " +
                                                     "set Estado = 0 " +
                                                     "where Id = @id", parameters,
                                                     commandType: System.Data.CommandType.Text);
            }
        }

        public async Task<IEnumerable<Usuario>> Listar(string username)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@username", username);
                //verificar tema del timeout
                return await connection.QueryAsync<Usuario>("dbo.UspBuscarUsuarios", parameters,
                                            commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public async Task<Usuario> ValidarUsuario(string email, string password)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@email", email);
                parameters.Add("@password", password);

                var usuario = await connection.QueryFirstOrDefaultAsync<Usuario>("[dbo].[uspValidarUsuario]",
                                                                parameters, commandType: System.Data.CommandType.StoredProcedure);
                return usuario;
            }
        }
        public async Task<Usuario> CrearUsuario(Usuario usuario)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string messageResult = "";
                var parameters = new DynamicParameters();
                parameters.Add("@Dni", usuario.DNI);
                parameters.Add("@Nombres", usuario.Nombres);
                parameters.Add("@Apellidos", usuario.Apellidos);
                parameters.Add("@Username", usuario.NombreUsuario);
                parameters.Add("@Password", usuario.Contraseña);
                parameters.Add("@IdRol", usuario.IdRol);
                parameters.Add("@OV_Message_Result", messageResult, System.Data.DbType.String,
                    System.Data.ParameterDirection.Output);

                Usuario usuarioCreado = await connection.QuerySingleAsync<Usuario>("[dbo].[uspCrearUsuario]",
                                                                parameters, commandType: System.Data.CommandType.StoredProcedure);

                messageResult = parameters.Get<string>("@OV_Message_Result");

                /*Especificar logica para el uso del messageResult*/

                return usuarioCreado;
            }
        }
    }
}
