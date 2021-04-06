using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hermes.Api.Models
{
    public class TipoComprobante
    {
        public int Id { get; set; }
        public string NombreNfc { get; set; }
        public string Serie { get; set; }
        public int TipoNfc { get; set; }
        public int CantidadDisponible { get; set; }
    }
}
