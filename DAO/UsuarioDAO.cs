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
    public class UsuarioDAO : BaseDAO<Usuario>, IUsuarioRepository
    {
        protected override string nomeTabela => "votacao.usuario";
        protected override string caracter => "@";
        protected override string sqlInsert
        {
            get
            {
                return string.Format("INSERT INTO {0} (id,nome," +
                    "email,senha,confirmPassword,idFilial) " +
                    "VALUES({1}id,{1}nome,{1}email," +
                    "{1}senha,{1}confirmPassword,{1}idFilial)", nomeTabela, caracter);
            }
        }
        protected override string sqlUpdate
        {
            get
            {
                return string.Format("UPDATE {0} SET nome={1}nome, " +
              "email={1}email,senha={1}senha, confirmPassword={1}confirmPassword,idFilial={1}idFilial " +
              "WHERE id={1}id", nomeTabela, caracter);
            }
        }

        public UsuarioDAO(IConfiguration configuration) : base(configuration)
        {

        }

        public void CreateUsuario(Usuario usuario)
        {
            usuario.confirmPassword = usuario.senha;
            usuario.id = Guid.NewGuid();
            base.Create(usuario);
        }

        public void DeleteUsuario(Usuario usuario)
        {
            base.Delete(usuario);
        }

        public IEnumerable<UsuarioEFilial> GetAllUsuario()
        {
            try
            {
                using (DbConnection conexao = FactoryConexao.getConnection(this.infConnection))
                {
                    return conexao.Query<UsuarioEFilial>("SELECT u.*, f.sigla siglaFilial FROM votacao.filial f INNER JOIN votacao.usuario u ON(u.idfilial = f.id)");
                }
            }
            catch (DbException ex)
            {

                throw ex;
            }
        }

        public Usuario GetUsuarioById(string id)
        {
            try
            {
                using (DbConnection conexao = FactoryConexao.getConnection(this.infConnection))
                {
                    return conexao.QueryFirstOrDefault<Usuario>(string.Format("select  * from {0} where id={1}id ", nomeTabela, caracter), new { id = Guid.Parse(id) });
                }
            }
            catch (DbException ex)
            {

                throw ex;
            }
        }

        public void UpdateUsuario(Usuario usuario)
        {
            try
            {
               using (DbConnection conexao = FactoryConexao.getConnection(this.infConnection))
                {
                    conexao.Execute(sqlUpdate, usuario);
                }
            }
            catch (DbException ex)
            {

                throw ex;
            }
        }

        public Usuario GetByUsuario(string email, string senha)
        {
            try
            {
                using (DbConnection conexao = FactoryConexao.getConnection(this.infConnection))
                {
                    return conexao.QueryFirstOrDefault<Usuario>(string.Format("select  * from {0} " + 
                     " where email={1}email and senha={1}senha ", nomeTabela, caracter), new { email = email, senha=senha });
                }
            }
            catch (DbException ex)
            {

                throw ex;
            }
        }

        public Usuario GetByUsuario(string filial, string email, string senha)
        {
            try
            {
                using (DbConnection conexao = FactoryConexao.getConnection(this.infConnection))
                {
                    return conexao.QueryFirstOrDefault<Usuario>(string.Format("select  * from {0} " +
                     " where idFilial={1}idFilial and email={1}email and senha={1}senha ", nomeTabela, caracter), 
                     new { idFilial= Guid.Parse(filial),
                           email = email,
                           senha = senha });
                }
            }
            catch (DbException ex)
            {

                throw ex;
            }
        }

        public Usuario GetUsuarioByEmail(string email)
        {

            try
            {
                using (DbConnection conexao = FactoryConexao.getConnection(this.infConnection))
                {
                    return conexao.QueryFirstOrDefault<Usuario>(string.Format("select  * from {0} where email={1}email ", nomeTabela, caracter), new { email = email });
                }
            }
            catch (DbException ex)
            {

                throw ex;
            }
        }
    }
}
