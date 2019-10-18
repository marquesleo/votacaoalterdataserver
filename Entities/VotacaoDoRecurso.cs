using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Models
{
    public class VotacaoDoRecurso : Base
    {

        [Required]
        public Guid idFilial { get; set; }
        
        [Required]
        public Guid idUsuario { get; set; }

        [Required]
        public Guid idRecurso { get; set; }

        [Required]
        public DateTime dtVotacao { get; set; }


        [Required]
        public string observacao { get; set; }

    }
}
