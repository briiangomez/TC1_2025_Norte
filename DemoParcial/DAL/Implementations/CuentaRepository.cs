using DemoParcial.DAL.Contracts;
using DemoParcial.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoParcial.DAL.Implementations
{
    public class CuentaRepository : IRepository<Cuenta>
    {
        private readonly Dictionary<Guid, Cuenta> _cuentas = new Dictionary<Guid, Cuenta>();

        public Cuenta GetById(Guid id)
        {
            if (_cuentas.TryGetValue(id, out var cuenta))
                return cuenta;

            throw new KeyNotFoundException($"No se encontró una cuenta con ID {id}");
        }

        public void Add(Cuenta cuenta)
        {
            if (_cuentas.ContainsKey(cuenta.Id))
                throw new InvalidOperationException($"Ya existe una cuenta con ID {cuenta.Id}");

            _cuentas[cuenta.Id] = cuenta;
        }

        public void Update(Cuenta cuenta)
        {
            if (!_cuentas.ContainsKey(cuenta.Id))
                throw new KeyNotFoundException($"No se puede actualizar. Cuenta no encontrada con ID {cuenta.Id}");

            _cuentas[cuenta.Id] = cuenta;
        }

        public IEnumerable<Cuenta> GetAll() => _cuentas.Values.ToList();
    }
}
