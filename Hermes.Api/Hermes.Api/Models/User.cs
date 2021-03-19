using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hermes.Api.Models
{
    public class User: IdentityUser
    {
        [MaxLength(50)]
        [Required]
        public string Nombre { get; set; }
        [Display(Name = "User Type")]
        public UserType UserType { get; set; }


    }
}
