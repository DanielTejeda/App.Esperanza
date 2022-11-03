using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace App.Esperanza.UI.MVC.ViewModels
{
    public class UsuarioLoginViewModel
    {
        [Required(ErrorMessage = "Debe indicar un nombre de usuario obligatoriamente")]
        [DataType(DataType.Text, ErrorMessage = "La estructura de usuario no es válida")]
        public string NombreUsuario { get; set; }

        [Required(ErrorMessage = "Debe indicar una constraseña obligatoriamente")]
        [DataType(DataType.Password)]
        [StringLength(15, ErrorMessage = "El número de caracteres excede el límite permitido")]
        public string Contraseña { get; set; }

        public string ReturnUrl { get; set; }
    }
}