using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Hermes.Api.Models
{
    public partial class Detallefactura
    {
        public int Id { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public int Cantidad { get; set; }
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal Precio { get; set; }
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal Itbis { get; set; }
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal Total { get; set; }

        public Articulo Articulo { get; set; }
        public Factura Factura { get; set; }
    }
}
