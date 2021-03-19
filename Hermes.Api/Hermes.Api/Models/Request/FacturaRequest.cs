using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hermes.Api.Models.Request
{
    public class FacturaRequest
    {
        
        public int idcliente { get; set; }
        public decimal total { get; set; }

        List<Detalle> detallefacturas { get; set; }
        public FacturaRequest()
        {
            this.detallefacturas = new List<Detalle>();
        }
    }
    public class Detalle
    {
        public int cantidad { get; set; }
        public decimal precio { get; set; }
        public decimal itbis { get; set; }
        public decimal total { get; set; }
        public int idarticulo { get; set; }
    }
}
