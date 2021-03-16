using System;
using System.Collections.Generic;

#nullable disable

namespace Hermes.Api.Models
{
    public partial class Articulo
    {
        public Articulo()
        {
            Detallefacturas = new HashSet<Detallefactura>();
        }

        public int Id { get; set; }

        public virtual ICollection<Detallefactura> Detallefacturas { get; set; }
    }
}
