using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hermes.Api.Models
{
    public class Proveedor
    {
        public int Id { get; set; }
        [MaxLength(50)]
        [Required]
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string NoIdentificacion { get; set; }
        public string Direccion { get; set; }
        public bool Estado { get; set; }
        public IdentificacionType ididentificacionType { get; set; }
    }
}
