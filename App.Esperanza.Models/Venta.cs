using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Esperanza.Models
{
    public class Venta
    {
        public int Id { get; set; }
        public int IdServicio { get; set; }
        public int IdUsuario { get; set; }
        public int IdCliente { get; set; }
        public int IdAgencia { get; set; }
        public string Detalle { get; set; }
        public string Partida { get; set; }
        public string Llegada { get; set; }
        public decimal Costo { get; set; }
        public decimal CostoAdicional { get; set; } 
        public string DetalleCostoAdicional { get; set; }
        public decimal Total { get; set; }
        public string EstadoServicio { get; set; }
        public DateTime FechaEntrega { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
