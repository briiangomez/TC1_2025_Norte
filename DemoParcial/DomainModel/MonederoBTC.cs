using DemoParcial.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoParcial.DomainModel
{
    public class MonederoBTC : Cuenta
    {
        public string Direccion { get; }

        public MonederoBTC(string direccion)
        {
            Direccion = direccion;
            Saldo = 0m;
        }

    }
}
