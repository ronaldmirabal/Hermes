using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hermes.Api.Models.Request
{
    public class FacturaRequest
    {
        public string NoFactura { get; set; }
        [Required]
        [Range(1,Double.MaxValue)]
        public int Idcliente { get; set; }

        [Required]
        public int IdTipoComprobante { get; set; }
        public decimal Total { get; set; }

        [Required]
        public List<Detalle> detallefacturas { get; set; }
        public FacturaRequest()
        {
            this.detallefacturas = new List<Detalle>();
        }
    }
    public class Detalle
    {
        public int Cantidad { get; set; }
        [Required]
        public int Factura { get; set; }
        public decimal Precio { get; set; }
        public decimal Itbis { get; set; }
        public decimal Total { get; set; }
        [Required]
        [Range(1, Double.MaxValue)]
        public int Idarticulo { get; set; }
    }
}
