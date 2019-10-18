using Contracts;
using System;
using System.Linq.Expressions;
using System.Data.Common;
using Entities;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using Entities.Models;
using Dapper;

namespace DAO
{
    public class FilialDAO : BaseDAO<Filial>, IFilialRepository
    {
        public FilialDAO(IConfiguration configuration) : base(configuration)
        {

        }


        protected override string nomeTabela => "votacao.filial";
        protected override string caracter => "@";
        protected override string sqlInsert
        {
            get
            {
                return string.Format("INSERT INTO {0} (id,nome," +
                    "sigla) VALUES({1}id,{1}nome,{1}sigla)", nomeTabela, caracter);
            }
        }
        protected override string sqlUpdate
        {
            get
            {
                return string.Format("UPDATE {0} SET nome={1}nome, " +
              "sigla={1}sigla WHERE id={1}id", nomeTabela, caracter);
            }
        }

        public void CreateFilial(Filial filial)
        {
            Create(filial);
        }

        public void DeleteFilial(Filial filial)
        {
            Delete(filial);
        }

        public IEnumerable<Filial> GetAll()
        {
            return FindAll();
        }

        public Filial GetFilialById(string id)
        {
            try
            {
                using (DbConnection conexao = FactoryConexao.getConnection(this.infConnection))
                {
                    return conexao.QueryFirstOrDefault<Filial>(string.Format("select  * from {0} where id={1}id ", nomeTabela, caracter), new { id = Guid.Parse(id) });
                }
            }
            catch (DbException ex)
            {

                throw ex;
            }
        }

        public Filial GetFilialBySiglaENome(string sigla, string nome)
        {
            try
            {
                using (DbConnection conexao = FactoryConexao.getConnection(this.infConnection))
                {
                    return conexao.QueryFirstOrDefault<Filial>(string.Format("select  * from {0} " +
                                                        " where upper(sigla)={1}sigla and upper(nome)={1}nome ", 
                                                            nomeTabela, caracter), 
                                                        new { sigla = sigla.ToUpper(), nome=nome.ToUpper() });
                }
            }
            catch (DbException ex)
            {

                throw ex;
            }
        }

        public void UpdateFilial(Filial filial)
        {
            Update(filial);
        }
    }
}
