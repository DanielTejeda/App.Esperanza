using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Esperanza.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string DNI { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string NombreUsuario { get; set; }
        //[DataType(DataType.Password)]
        [Computed]
        public string Contraseña { get; set; }
        public bool Estado { get; set; }
        public int IdRol { get; set; }

        //Datos de Auditoría
        public DateTime? FechaCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
    }
}
