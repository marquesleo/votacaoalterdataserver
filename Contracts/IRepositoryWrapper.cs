using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
    public interface IRepositoryWrapper
    {
        IUsuarioRepository Usuario { get; }

        IFilialRepository Filial { get; }

        IRecursoRepository Recurso { get;  }

        IVotacaoDoRecursoRepository VotacaoRecurso { get; }
       
    }
}
