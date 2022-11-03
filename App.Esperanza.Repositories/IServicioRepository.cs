using App.Esperanza.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Esperanza.Repositories
{
    public interface IServicioRepository : IRepository<Servicio>
    {
        Task<int> Eliminar(int id);
    }
}
