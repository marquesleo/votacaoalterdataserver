using System;
using System.Collections.Generic;
using System.Text;
using Entities;
using Entities.Models;

namespace Contracts
{
    public interface IFilialRepository : IRepositoryBase<Filial>
    {
        IEnumerable<Filial> GetAll();
        Filial GetFilialById(string id);
        Filial GetFilialBySiglaENome(string sigla, string nome);
        void CreateFilial(Filial filial);
        void UpdateFilial(Filial filial);
        void DeleteFilial(Filial filial);
    }
}
