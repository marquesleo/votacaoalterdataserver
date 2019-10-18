using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Contracts;
using Entities;
using Entities.Models;
using Microsoft.Extensions.Configuration;
using DAO;

namespace Repository
{
   public class RecursoRepository : RepositoryBase<Recurso>, IRecursoRepository
    {

        private RecursoDAO recursoDAO;
        public RecursoRepository(IConfiguration configuration): base(configuration)
        {
            recursoDAO = DAO.Factory.FactoryRecurso.getDAO(configuration, infConnection);
        }

        public void CreateRecurso(Recurso recurso)
        {
          
            recurso.id = Guid.NewGuid();
            recursoDAO.CreateRecurso(recurso);
        }

        public void DeleteRecurso(Recurso recurso)
        {
            recursoDAO.DeleteRecurso(recurso);
        }

        public IEnumerable<Recurso> GetAll()
        {
            return recursoDAO.GetAll();
        }

        public Recurso GetRecursoById(string id)
        {
            return recursoDAO.GetRecursoById(id);
        }

        public IEnumerable<Entities.BO.RecursoParaVotacao> GetRecursosNaoVotados(string idusuario)
        {
            return recursoDAO.GetRecursosNaoVotados(idusuario);
        }

        public void UpdateRecurso(Recurso recurso)
        {
            recursoDAO.UpdateRecurso(recurso);
        }
    }
}
