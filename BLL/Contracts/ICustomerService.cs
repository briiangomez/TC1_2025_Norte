using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Contracts
{
    public interface ICustomerService : IGenericService<Customer>
    {
        ///Filtros
        ///
        Customer GetByName(string name);

        Customer GetByCode(int code);
    }
}
