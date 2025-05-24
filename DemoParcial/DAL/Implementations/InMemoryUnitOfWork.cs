using DemoParcial.DAL.Contracts;
using DemoParcial.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoParcial.DAL.Implementations
{
    public class InMemoryUnitOfWork : IUnitOfWork, IDisposable
    {
        //Si tengo mas repositorios, los agrego aca.....
        public IRepository<Operacion> Operaciones { get; }

        public IRepository<Cuenta> Cuentas { get; }

        public InMemoryUnitOfWork()
        {
            Operaciones = new OperacionRepository();
            Cuentas = new CuentaRepository();
        }

        public void Commit()
        {
            // No-op. Acá podrías loguear o simular un commit si querés. db.SaveChanges()
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }

}
