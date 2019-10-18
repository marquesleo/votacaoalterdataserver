using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
    public interface IVotacaoDoRecursoRepository : IRepositoryBase<VotacaoDoRecurso>
    {
        VotacaoDoRecurso GetVotacaoDoRecursoById(string id);

        IEnumerable<VotacaoDoRecurso> GetVotosDoUsuario(string idUsuario);

        VotacaoDoRecurso GetVotacaoDoRecursoByFilialUsuarioERecurso(string idFilial, 
            string idUsuario,
            string idRecurso);
    }
}
