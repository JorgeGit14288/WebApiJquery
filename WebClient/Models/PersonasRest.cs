using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebClient.Models
{
    public class PersonasRest
    {
        [Required]
        public int idPersona { get; set; }
        [Required]
        public string nombre { get; set; }
        public string direccion { get; set; }
        public byte[] imagen { get; set; }
        public Nullable<System.DateTime> nacimiento { get; set; }
        public string telefono { get; set; }
        public string email { get; set; }
    }
}