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
    public class UsuarioRepository : RepositoryBase<Usuario>, IUsuarioRepository
     {
        private UsuarioDAO usuarioDAO;

        public UsuarioRepository(IConfiguration configuration)
       : base(configuration)
        {
            usuarioDAO = DAO.Factory.FactoryUsuario.getDAO(configuration, infConnection);
        }

        public void CreateUsuario(Usuario usuario)
        {
            usuarioDAO.CreateUsuario(usuario);
        }

        public void DeleteUsuario(Usuario usuario)
        {
            usuarioDAO.DeleteUsuario(usuario);
        }

        public IEnumerable<UsuarioEFilial> GetAllUsuario()
        {
            return usuarioDAO.GetAllUsuario();
        }

        public Usuario GetUsuarioById(string id)
        {
            return usuarioDAO.GetUsuarioById(id);
        }

        public void UpdateUsuario(Usuario usuario)
        {
            usuarioDAO.UpdateUsuario(usuario);
        }

        public Usuario GetByUsuario(string email, string senha)
        {
            return usuarioDAO.GetByUsuario(email, senha);
        }

        public Usuario GetUsuarioByEmail(string email)
        {
            return usuarioDAO.GetUsuarioByEmail(email);
        }

        public Usuario GetByUsuario(string filial, string email, string senha)
        {
            return usuarioDAO.GetByUsuario(filial, email, senha);
        }
    }
}
