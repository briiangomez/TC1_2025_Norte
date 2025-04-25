using DAO.Contracts;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Implementations.SqlServer.Adapters
{
    public sealed class CustomerAdapter : IAdapter<Customer>
    {
        #region Singleton
        private readonly static CustomerAdapter _instance = new CustomerAdapter();

        public static CustomerAdapter Current
        {
            get
            {
                return _instance;
            }
        }

        private CustomerAdapter()
        {
            //Implent here the initialization of your singleton
        }

        #endregion

        public Customer Get(object[] values)
        {
            return new Customer()
            {
                IdCustomer = Guid.Parse(values[(int)CustomerFields.IdCustomer].ToString()),
                Name = values[(int)CustomerFields.Name].ToString(),
                Code = Int32.Parse(values[(int)CustomerFields.Code].ToString())
            };
        }
    }

    internal enum CustomerFields
    {
        IdCustomer = 0,
        Name = 1,
        Code = 2
    }
}
