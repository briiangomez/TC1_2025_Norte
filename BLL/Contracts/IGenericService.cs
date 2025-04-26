using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Contracts
{
    public interface IGenericService<T> 
    {
        List<T> GetAll();

        T GetById(Guid id);

        void Insert(T entity);

        void Update(T entity);

        void Delete(Guid id);

        bool Exists(Guid id);
    }
}
