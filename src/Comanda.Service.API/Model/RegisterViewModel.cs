using System.ComponentModel.DataAnnotations;

namespace Comanda.Service.API.Model
{
    public class RegisterViewModel
    {
        [Required]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "PASSWORD_MIN_LENGTH", MinimumLength = 6)]
        public string Password { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
