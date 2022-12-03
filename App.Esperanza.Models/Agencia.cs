using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Esperanza.Models
{
    public class Agencia
    {
        public int Id { get; set; }
        public string Direccion { get; set; }
        [StringLength(9, ErrorMessage = "El celular solo debe tener 9 dígitos")]
        public string Celular { get; set; }
        public string Departamento { get; set; }
        public bool Estado { get; set; }
        [Required(ErrorMessage = "Debe indicar un Nombre obligatoriamente.")]
        public string Nombre { get; set; }

    }
}
