using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.BO
{
    public class RecursoParaVotacao:Entities.Models.Recurso
    {
        public bool selecionado { get; set; }
        public string observacao { get; set; }
        public  Guid idusuario { get; set; }
   
    }
}
