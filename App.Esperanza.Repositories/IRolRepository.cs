using App.Esperanza.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Esperanza.Repositories
{
    public interface IRolRepository : IRepository<Rol>
    {
        Task<int> Eliminar(int id);
    }
}
