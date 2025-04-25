using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Contracts
{
    public interface IGenericRepository<T>
    {
        ///Pensamos un CRUD o ABM para cualquier entidad
        ///

        List<T> GetAll();

        T GetById(Guid id);

        void Insert(T entity);

        void Update(T entity);

        void Delete(Guid id);

        bool Exists(Guid id);
    }
}
