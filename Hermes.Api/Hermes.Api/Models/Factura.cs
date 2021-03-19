using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Hermes.Api.Models
{
    public partial class Factura
    {
      

        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal Total { get; set; }
        public Cliente cliente{ get; set; }
        public virtual ICollection<Detallefactura> Detallefacturas { get; set; }
    }
}
