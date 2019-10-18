using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAO.Factory
{
    public class FactoryFilial
    {
        public static FilialDAO getDAO(IConfiguration confg,
                                  infConnection infConnection)
        {

            return new FilialDAO(confg);

        }
    }
}
