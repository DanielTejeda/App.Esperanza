using App.Esperanza.Repositories;
using App.Esperanza.Repositories.Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Esperanza.UnitOfWork
{
    public class VentasUnitOfWork : IUnitOfWork
    {
        public VentasUnitOfWork(string connectionString)
        {
            Agencias = new AgenciaRepository(connectionString);
            Servicios = new ServicioRepository(connectionString);
            Roles = new RolRepository(connectionString);
            Clientes = new ClienteRepository(connectionString);
            Usuarios = new UsuarioRepository(connectionString);
            Ventas = new VentaRepository(connectionString);

        }
        public IAgenciaRepository Agencias
        {
            get;
            private set;
        }
        public IServicioRepository Servicios
        {
            get;
            private set;
        }
        public IRolRepository Roles
        {
            get;
            private set;
        }
        public IClienteRepository Clientes
        {
            get;
            private set;
        }
        public IUsuarioRepository Usuarios
        {
            get;
            private set;
        }
        public IVentaRepository Ventas
        {
            get;
            private set;
        }


    }
}
