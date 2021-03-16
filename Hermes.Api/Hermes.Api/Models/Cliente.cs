using System;
using System.Collections.Generic;

#nullable disable

namespace Hermes.Api.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            Facturas = new HashSet<Factura>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Identificacion { get; set; }
        public string Direccion { get; set; }

        public virtual ICollection<Factura> Facturas { get; set; }
    }
}
