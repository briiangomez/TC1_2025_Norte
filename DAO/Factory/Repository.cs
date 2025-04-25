using DAO.Contracts;
using DAO.Factory.Enums;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Factory
{

    public static class Repository
    {
        static int backendType = int.Parse(ConfigurationManager.AppSettings["BackendType"]);

        public static ICustomerRepository GetCustomerInstance()
        {
            if (backendType == (int)BackendType.Memory)
            {
                return new DAO.Implementations.Memory.CustomerRepository();
            }
            else if (backendType == (int)BackendType.SqlServer)
            {
                return new DAO.Implementations.SqlServer.CustomerRepository();
            }
            throw new Exception("PROBLEMAS");
        }

    }

}
