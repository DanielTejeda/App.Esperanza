using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Esperanza.Models
{
    public class Servicio
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Debe indicar un Nombre obligatoriamente.")]
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool Estado { get; set; }

    }
}
