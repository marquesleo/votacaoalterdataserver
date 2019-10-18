using Microsoft.Extensions.Configuration;

namespace DAO.Factory
{
    public class FactoryUsuario
    {

        public static UsuarioDAO getDAO(IConfiguration confg,
                                  infConnection infConnection)
        {

            return new UsuarioDAO(confg);

        }
    }
}
