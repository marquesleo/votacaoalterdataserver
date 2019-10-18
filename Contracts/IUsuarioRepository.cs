using System;
using System.Collections.Generic;
using System.Text;
using Entities;
using Entities.Models;

namespace Contracts
{
   public interface IUsuarioRepository : IRepositoryBase<Usuario>
    {
        IEnumerable<UsuarioEFilial> GetAllUsuario();
        Usuario GetUsuarioById(String id);

        Usuario GetUsuarioByEmail(string email);
        void CreateUsuario(Usuario usuario);
        Usuario GetByUsuario(string email, string senha);

        Usuario GetByUsuario(string filial, string email, string senha);
            
        void UpdateUsuario(Usuario usuario);
        void DeleteUsuario(Usuario usuario);
    }
   
}
