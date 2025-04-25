using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Contracts
{
    public interface ICustomerRepository : IGenericRepository<Customer>
    {
        ///Filtros
        ///

        Customer GetByName(string name);

        Customer GetByCode(int code);
    }
}
