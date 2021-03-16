using System;
using System.Collections.Generic;

#nullable disable

namespace Hermes.Api.Models
{
    public partial class Detallefactura
    {
        public int Id { get; set; }
        public int IdFactura { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public decimal Itbis { get; set; }
        public decimal Total { get; set; }
        public int IdArticulo { get; set; }

        public Articulo IdArticuloNavigation { get; set; }
        public Factura IdFacturaNavigation { get; set; }
    }
}
