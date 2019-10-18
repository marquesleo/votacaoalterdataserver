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
    public class VotacaoDoRecursoDAO : BaseDAO<VotacaoDoRecurso>, IVotacaoDoRecursoRepository
    {

        public VotacaoDoRecursoDAO(IConfiguration configuration) : base(configuration)
        {

        }
        protected override string nomeTabela => "votacao.votacaodorecurso";
        protected override string caracter => "@";
        protected override string sqlInsert
        {
            get
            {
                return string.Format("INSERT INTO {0} (id,idFilial,idUsuario,idRecurso,dtVotacao" +
                    ") VALUES({1}id,{1}idFilial,{1}idUsuario,{1}idRecurso,{1}dtVotacao)", nomeTabela, caracter);
            }
        }
        protected override string sqlUpdate
        {
            get
            {
                return "";
            }
        }

        public VotacaoDoRecurso GetVotacaoDoRecursoByFilialUsuarioERecurso(string idFilial, string idUsuario, string idRecurso)
        {
            try
            {
                using (DbConnection conexao = FactoryConexao.getConnection(this.infConnection))
                {
                    return conexao.QueryFirstOrDefault<VotacaoDoRecurso>(string.Format("select * from {0} " + 
                            " where idFilial={1}idFilial and idUsuario={1}idUsuario and idRecurso={1}idRecurso ",
                                nomeTabela, caracter), new { id = Guid.Parse(idFilial),
                                                             idUsuario = Guid.Parse(idUsuario),
                                                             idRecurso = Guid.Parse(idRecurso)
                                                            });
                };

            }
            catch (DbException ex)
            {

                throw ex;
            }
        }

        public VotacaoDoRecurso GetVotacaoDoRecursoById(string id)
        {
            try
            {
                using (DbConnection conexao = FactoryConexao.getConnection(this.infConnection))
                {
                    return conexao.QueryFirstOrDefault<VotacaoDoRecurso>(string.Format("select * from {0} where id={1}id ",
                                nomeTabela, caracter), new { id = Guid.Parse(id) });
                };

            }
            catch (DbException ex)
            {

                throw ex;
            }
        }

        public IEnumerable<VotacaoDoRecurso> GetVotosDoUsuario(string idUsuario)
        {
            try
            {
                using (DbConnection conexao = FactoryConexao.getConnection(this.infConnection))
                {
                    return conexao.Query<VotacaoDoRecurso>(string.Format("select * from {0} where idUsuario={1}idUsuario ",
                                nomeTabela, caracter), new { idUsuario = Guid.Parse(idUsuario) });
                };

            }
            catch (DbException ex)
            {

                throw ex;
            }
        }
    }
}
