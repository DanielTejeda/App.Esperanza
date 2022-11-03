using App.Esperanza.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Esperanza.UnitOfWork
{
    public interface IUnitOfWork
    {
        IAgenciaRepository Agencias { get; }
        IServicioRepository Servicios { get; }
        IRolRepository Roles { get; }
        IClienteRepository Clientes { get; }
        IUsuarioRepository Usuarios { get; }
        IVentaRepository Ventas { get; }
    }
}
