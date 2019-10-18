using System;
using System.Collections.Generic;
using System.Text;
using Npgsql;
using System.Data.Common;

namespace DAO
{
    public static class FactoryConexao
    {

        public static DbConnection getConnection(infConnection infConnection)
        {
             return new NpgsqlConnection(infConnection.conexao);
        }
    }
}
