using System;
using System.Collections.Generic;
using System.Text;
using Contracts;
using Entities;
using Microsoft.Extensions.Configuration;
using Repository;

namespace Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private IUsuarioRepository _usuario;

        private IRecursoRepository _recurso;

        private IFilialRepository _filial;

        private IVotacaoDoRecursoRepository _votacaoDoRecurso;
    
        private IConfiguration _configuration;
        public RepositoryWrapper(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public IUsuarioRepository Usuario
        {
            get
            {
                if (_usuario == null)
                 _usuario = new UsuarioRepository(_configuration);
                

                return _usuario;
            }
        }

        public IRecursoRepository Recurso
        {
            get
            {
                if (_recurso == null)
                    _recurso = new RecursoRepository(_configuration);


                return _recurso;
            }
        }

       

        public IFilialRepository Filial
        {
            get
            {
                if (_filial == null)
                    _filial = new FilialRepository(_configuration);


                return _filial;
            }
        }

        public IVotacaoDoRecursoRepository VotacaoRecurso
        {
            get
            {
                if (_votacaoDoRecurso == null)
                    _votacaoDoRecurso = new VotacaoDoRecursoRepository(_configuration);


                return _votacaoDoRecurso;
            }
        }

    }
}
