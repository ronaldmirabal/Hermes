using System;
using System.Collections.Generic;

#nullable disable

namespace Hermes.Api.Models
{
    public partial class Factura
    {
        public Factura()
        {
            Detallefacturas = new HashSet<Detallefactura>();
        }

        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }
        public int? IdCliente { get; set; }

        public virtual Cliente IdClienteNavigation { get; set; }
        public virtual ICollection<Detallefactura> Detallefacturas { get; set; }
    }
}
