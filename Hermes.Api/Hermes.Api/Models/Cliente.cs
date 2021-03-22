using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Hermes.Api.Models
{
    public partial class Cliente
    {
        public int Id { get; set; }
        [MaxLength(50)]
        [Required]
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Identificacion { get; set; }
        public string Direccion { get; set; }
        public bool Estado { get; set; }
        public IdentificacionType identificacionType { get; set; }

        public virtual ICollection<Factura> Facturas { get; set; }
    }
}
