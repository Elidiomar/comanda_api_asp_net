using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace Comanda.Infra.Cross.Identity.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public Guid BillingAddressId { get; set; }

        [Required]
        public string Name { get; set; }
        
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string AvatarURL { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "Data de Registro")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd'T'HH:mm:ss.fff}", ApplyFormatInEditMode = true)]
        public DateTime DateRegistered { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "Data de Controle")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd'T'HH:mm:ss.fff}", ApplyFormatInEditMode = true)]
        public DateTime Control { get; set; }
    }
}
