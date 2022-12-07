using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App.Esperanza.WebApi.DTO
{
    public class RespuestaResultado
    {
        public int Id { get; set; }
        public string Mensaje { get; set; }
        public string Estado { get; set; }
    }
}