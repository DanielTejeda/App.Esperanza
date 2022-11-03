using App.Esperanza.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Esperanza.Repositories
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        Task<IEnumerable<Usuario>> Listar(string username);
        Task<int> Eliminar(int id);

        Task<Usuario> ValidarUsuario(string username, string password); //Login
        Task<Usuario> CrearUsuario(Usuario usuario); //Register
    }
}
