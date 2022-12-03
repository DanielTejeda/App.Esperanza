using App.Esperanza.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Esperanza.Repositories
{
    public interface IVentaRepository : IRepository<Venta>
    {
        Task<IEnumerable<Venta>> ListaPendientes();
        Task<IEnumerable<Venta>> ListarPorCliente(int idCliente);
        Task<IEnumerable<Venta>> ListarPorUsuario(int idUsuario);
    }
}
