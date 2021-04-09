using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hermes.Api.Models.Request
{
    public class ProveedorRequest
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string telefono { get; set; }
        public string Noidentificacion { get; set; }
        public string direccion { get; set; }
        public int idtipoidentificacion { get; set; }
        public bool estado { get; set; }
    }
}
