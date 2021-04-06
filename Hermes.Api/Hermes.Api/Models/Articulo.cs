using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Hermes.Api.Models
{
    public class Articulo
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        [MaxLength(100, ErrorMessage = "The filed {0} must contain less than {1} characteres.")]
        [Required]
        public string Nombre { get; set; }
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal Precio { get; set; }

        [DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal Costo { get; set; }

        [DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal Itbis { get; set; }

        [DataType(DataType.MultilineText)]
        public string Descripcion { get; set; }

        [MaxLength(20)]
        public string Tipo { get; set; }
        public bool Estado { get; set; }
        public Categoria categoria { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal Stock { get; set; }

        public virtual ICollection<Detallefactura> Detallefacturas { get; set; }

        public static explicit operator Articulo(List<Articulo> v)
        {
            throw new NotImplementedException();
        }
    }
}
