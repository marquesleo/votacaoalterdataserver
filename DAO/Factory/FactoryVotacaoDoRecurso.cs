using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAO.Factory
{
    public class FactoryVotacaoDoRecurso
    {

        public static VotacaoDoRecursoDAO getDAO(IConfiguration confg,
                                 infConnection infConnection)
        {

            return new VotacaoDoRecursoDAO(confg);

        }
    }
}
