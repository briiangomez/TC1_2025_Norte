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

        public MonederoBTC(Guid id,string direccion)
        {
            Id = id;
            Direccion = direccion;
            Saldo = 0m;
        }

    }
}
