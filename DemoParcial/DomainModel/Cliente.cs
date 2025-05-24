using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoParcial.DomainModel
{
    public class Cliente
    {
        public string CUIT { get; }
        public string Nombre { get; }
        public List<Cuenta> Cuentas { get; }

        public Cliente(string cuit, string nombre)
        {
            CUIT = cuit;
            Nombre = nombre;
            Cuentas = new List<Cuenta>();
        }

        public void AgregarCuenta(Cuenta cuenta)
        {
            Cuentas.Add(cuenta);
            cuenta.Cliente = this;
        }
    }
}
