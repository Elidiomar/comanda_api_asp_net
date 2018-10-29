using System.ComponentModel.DataAnnotations;

namespace Comanda.Service.API.Model
{
    public class LoginViewModel
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
