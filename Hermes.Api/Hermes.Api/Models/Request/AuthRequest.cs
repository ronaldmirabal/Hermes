using System.ComponentModel.DataAnnotations;

namespace Hermes.Api.Models.Request
{
    public class AuthRequest
    {
        [Required]
        public string username { get; set; }
        public string password { get; set; }
    }
}
