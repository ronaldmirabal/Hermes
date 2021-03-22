﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hermes.Api.Models
{
    public class IdentificacionType
    {
        public int Id { get; set; }
        [MaxLength(50)]
        [Required]
        public string Nombre { get; set; }
    }
}
