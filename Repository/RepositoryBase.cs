using Contracts;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.Extensions.Configuration;
using DAO;


namespace Repository
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {

        protected IConfiguration _configuration;
        protected infConnection infConnection { get; set; }

        public RepositoryBase(IConfiguration configuration)
        {

            _configuration = configuration;
            infConnection = DAO.MyDB.getStringConn(this._configuration);

        }
        public void Create(T entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> FindAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> FindByCondition(System.Linq.Expressions.Expression<Func<T, bool>> expression)
        {
            throw new NotImplementedException();
        }
        
        public void Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
