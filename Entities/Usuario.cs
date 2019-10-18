using System;
using System.ComponentModel.DataAnnotations;
namespace Entities.Models
{
    public class Usuario:Base
    {
        [Required]
        public string nome { get; set; }

        [Required]
        [Display(Name = "E-mail")]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail em formato inválido.")]
        public string email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string senha { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Senha", ErrorMessage = "The password and confirmation password do not match.")]
        public string confirmPassword { get; set; }


        [Required]
        public Guid idFilial { get; set; }

    }
}
