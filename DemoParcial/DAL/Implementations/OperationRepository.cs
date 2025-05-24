using DemoParcial.DAL.Contracts;
using DemoParcial.DAL.Singleton;
using DemoParcial.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoParcial.DAL.Implementations
{
    public class OperacionRepository : IRepository<Operacion>
    {
        private readonly MemoryDatabase _db = MemoryDatabase.Current;

        public void Add(Operacion item)
        {
            _db.Operaciones.Add(item);
        }

        public IEnumerable<Operacion> GetAll()
        {
            return _db.Operaciones;
        }

        public Operacion GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update(Operacion cuenta)
        {
            throw new NotImplementedException();
        }
    }

}
