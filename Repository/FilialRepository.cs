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
    public class FilialRepository : RepositoryBase<Filial>, IFilialRepository
    {
        private FilialDAO filialDAO;
        public FilialRepository(IConfiguration configuration) : base(configuration)
        {
            filialDAO = DAO.Factory.FactoryFilial.getDAO(configuration, infConnection);
        }

        public void CreateFilial(Filial filial)
        {
            filial.id = Guid.NewGuid();
            filialDAO.CreateFilial(filial);
        }

        public void DeleteFilial(Filial filial)
        {
            filialDAO.DeleteFilial(filial);
        }

        public IEnumerable<Filial> GetAll()
        {
            return filialDAO.FindAll();
        }

        public Filial GetFilialById(string id)
        {
            return filialDAO.GetFilialById(id);
        }

        public Filial GetFilialBySiglaENome(string sigla, string nome)
        {
            return filialDAO.GetFilialBySiglaENome(sigla, nome);
        }

        public void UpdateFilial(Filial filial)
        {
            filialDAO.UpdateFilial(filial);
        }
    }
}
