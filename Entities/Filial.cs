using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Models
{
    public class Filial:Base
    {
        [Required]
        [Display(Name = "Nome")]
        [MaxLength(50,ErrorMessage = "Nome não pode ter mais que 50 caracteres")]
        public string nome { get; set; }

        [Required]
        [Display(Name = "Sigla")]
        [MaxLength(2, ErrorMessage = "Sigla não pode ter mais que 2 caracteres")]
        public string sigla { get; set; }
    }
}
