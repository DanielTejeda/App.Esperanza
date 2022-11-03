using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Esperanza.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Tipo { get; set; }
        public string DNI { get; set; }
        public string RUC { get; set; }
        [Required]
        public string Nombre { get; set; }
        public string Celular { get; set; }
        public bool Estado { get; set; }

        //Datos de Auditoría
        public DateTime? FechaCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
    }
}
