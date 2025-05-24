using DemoParcial.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoParcial.DomainModel
{
    public abstract class Cuenta
    {

        public Guid Id { get; set; }
        public decimal Saldo { get; protected set; }

        public Cliente Cliente { get; set; }


        public void Depositar(decimal monto)
        {
            if (monto < 0)
                throw new ArgumentException("El monto a depositar debe ser positivo.");
            Saldo += monto;
        }

        public void Retirar(decimal monto)
        {
            if (monto < 0)
                throw new ArgumentException("El monto a retirar debe ser positivo.");
            if (Saldo < monto)
                throw new InvalidOperationException("Saldo insuficiente.");
            Saldo -= monto;
        }

    }
}
