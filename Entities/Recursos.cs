using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Models
{
    public class Recurso:Base
    {

        [Required]
        [Display(Name = "Recurso")]
        public string nome { get; set; }

        [Required]
        public Guid idFilial { get; set; }
    }
}
