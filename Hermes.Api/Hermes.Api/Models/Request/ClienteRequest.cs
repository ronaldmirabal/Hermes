using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hermes.Api.Models.Request
{
    public class ClienteRequest
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string telefono { get; set; }
        public string identificacion { get; set; }
        public string direccion { get; set; }
    }
}
