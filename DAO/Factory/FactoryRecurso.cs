using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAO.Factory
{
   public class FactoryRecurso
    {
        public static RecursoDAO getDAO(IConfiguration confg,
                                  infConnection infConnection)
        {

            return new RecursoDAO(confg);

        }
    }
}
