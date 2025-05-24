using DemoParcial.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoParcial.DAL.Contracts
{
    public interface IUnitOfWork
    {
        IRepository<Operacion> Operaciones { get; }
        IRepository<Cuenta> Cuentas { get; }
        void Commit(); // En memoria no hace nada, pero en EF sería SaveChanges
    }

}
