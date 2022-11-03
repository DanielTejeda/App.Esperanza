using App.Esperanza.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Esperanza.Repositories
{
    public interface IAgenciaRepository: IRepository<Agencia>
    {
        Task<int> Eliminar(int id);
    }
}
