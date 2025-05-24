using DemoParcial.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoParcial.DomainModel
{
    public class CajaAhorro : Cuenta
    {
        public string CBU { get; }

        public CajaAhorro(Guid id, string cbu)
        {
            Id = id;
            CBU = cbu;
            Saldo = 0m;
        }
    }
}
