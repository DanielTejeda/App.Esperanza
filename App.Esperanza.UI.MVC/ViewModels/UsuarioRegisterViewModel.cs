using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace App.Esperanza.UI.MVC.ViewModels
{
    public class UsuarioRegisterViewModel
    {
        public string DNI { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        [Required(ErrorMessage = "Debe indicar el nombre de usuario obligatoriamente")]
        public string NombreUsuario { get; set; }
        [Required(ErrorMessage = "Debe indicar una contraseña obligatoriamente")]
        [DataType(DataType.Password)]
        [StringLength(15, ErrorMessage = "El número de caracteres excede el límite permitido")]
        public string Contraseña { get; set; }
        [Required(ErrorMessage = "Debe confirmar la contraseña obligatoriamente")]
        [DataType(DataType.Password)]
        [StringLength(15, ErrorMessage = "El número de caracteres excede el límite permitido")]
        [Compare("Contraseña", ErrorMessage = "La contraseña y la confirmación de contraseña no coinciden")]
        public string ConfirmContraseña { get; set; }
    }
}