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
    public class RecursoDAO : BaseDAO<Recurso>, IRecursoRepository
    {
        public RecursoDAO(IConfiguration configuration) : base(configuration)
        {

        }
        protected override string nomeTabela => "votacao.recurso";
        protected override string caracter => "@";
        protected override string sqlInsert
        {
            get
            {
                return string.Format("INSERT INTO {0} (id,nome,idFilial" +
                    ") VALUES({1}id,{1}nome,{1}idFilial)", nomeTabela, caracter);
            }
        }
        protected override string sqlUpdate
        {
            get
            {
                return string.Format("UPDATE {0} SET nome={1}nome,idFilial={1}idFilial " +
              " WHERE id={1}id", nomeTabela, caracter);
            }
        }

        public void CreateRecurso(Recurso recurso)
        {
            Create(recurso);
        }

        public void DeleteRecurso(Recurso recurso)
        {
            Delete(recurso);
        }

        public IEnumerable<Recurso> GetAll()
        {
            return FindAll();
        }

 

        public Recurso GetRecursoById(string id)
        {
            try
            {
                using (DbConnection conexao = FactoryConexao.getConnection(this.infConnection))
                {
                    return conexao.QueryFirstOrDefault<Recurso>(string.Format("select * from {0} where id={1}id ",
                                nomeTabela, caracter), new { id =  Guid.Parse(id)  });
                };
                
            }
            catch (DbException ex)
            {

                throw ex;
            }
        }

        public IEnumerable<Entities.BO.RecursoParaVotacao> GetRecursosNaoVotados(string  idusuario)
        {
            try
            {
                using (DbConnection conexao = FactoryConexao.getConnection(this.infConnection))
                {
                    var query = string.Format("SELECT * FROM {0} WHERE id NOT IN (SELECT idrecurso FROM votacao.votacaodorecurso  WHERE idusuario ={1}idusuario)", nomeTabela, caracter);

                   
                    return conexao.Query<Entities.BO.RecursoParaVotacao>(query, new { idusuario =  Guid.Parse( idusuario) });
                };

            }
            catch (DbException ex)
            {

                throw ex;
            }
        }

        public void UpdateRecurso(Recurso recurso)
        {
            Update(recurso);
        }
    }
}
