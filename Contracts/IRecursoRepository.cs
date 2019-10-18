using System;
using System.Collections.Generic;
using System.Text;
using Entities;
using Entities.Models;

namespace Contracts
{
    public interface IRecursoRepository : IRepositoryBase<Recurso>
    {
        IEnumerable<Recurso> GetAll();
        Recurso GetRecursoById(string id);

        IEnumerable<Entities.BO.RecursoParaVotacao> GetRecursosNaoVotados(string idusuario);

        void CreateRecurso(Recurso recurso);
        void UpdateRecurso(Recurso recurso);
        void DeleteRecurso(Recurso recurso);

     
    }
}
