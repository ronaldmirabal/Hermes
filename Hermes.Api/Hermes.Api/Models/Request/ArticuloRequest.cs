using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hermes.Api.Models.Request
{
    public class ArticuloRequest
    {
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        public string Codigo { get; set; }
        public decimal Precio { get; set; }
        public decimal Costo { get; set; }
        public decimal Itbis { get; set; }
        public string Descripcion { get; set; }
        public string Tipo { get; set; }
        public bool Estado { get; set; }
        public int IdCategoria { get; set; }
        public decimal Stock { get; set; }
    }
}
