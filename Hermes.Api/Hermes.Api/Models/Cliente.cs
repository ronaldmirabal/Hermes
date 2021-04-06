using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

#nullable disable

namespace Hermes.Api.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        [MaxLength(50)]
        [Required]
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Identificacion { get; set; }
        public string Direccion { get; set; }
        public bool Estado { get; set; }
        public IdentificacionType ididentificacionType { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual ICollection<Factura> Facturas { get; set; }
    }
}
