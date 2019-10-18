using Contracts;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Entities;
using Entities.Models;
using Microsoft.Extensions.Configuration;
using DAO;

namespace Repository
{
    public class VotacaoDoRecursoRepository : RepositoryBase<VotacaoDoRecurso>, IVotacaoDoRecursoRepository
    {
        private VotacaoDoRecursoDAO votacaoDoRecursoDAO;

        public VotacaoDoRecursoRepository(IConfiguration configuration)
       : base(configuration)
        {
            votacaoDoRecursoDAO = DAO.Factory.FactoryVotacaoDoRecurso.getDAO(configuration, infConnection);
        }
    
        public VotacaoDoRecurso GetVotacaoDoRecursoByFilialUsuarioERecurso(string idFilial, string idUsuario, string idRecurso)
        {
            return votacaoDoRecursoDAO.GetVotacaoDoRecursoByFilialUsuarioERecurso(idFilial, idUsuario, idRecurso);
        }

        public VotacaoDoRecurso GetVotacaoDoRecursoById(string id)
        {
            return votacaoDoRecursoDAO.GetVotacaoDoRecursoById(id);
        }

        public IEnumerable<VotacaoDoRecurso> GetVotosDoUsuario(string idUsuario)
        {
            return votacaoDoRecursoDAO.GetVotosDoUsuario(idUsuario);
        }
    }
}
