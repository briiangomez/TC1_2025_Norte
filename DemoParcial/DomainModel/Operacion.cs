using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoParcial.DomainModel
{
    public class Operacion
    {
        // Propiedades

        public Guid Id { get; set; }
        public Cuenta CuentaOrigen { get; set; }
        public Cuenta CuentaDestino { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Monto { get; set; }
        public TipoOperacion TipoOperacion { get; set; }

        // Constructor
        public Operacion(Cuenta cuentaOrigen, Cuenta cuentaDestino, DateTime fecha, decimal monto, TipoOperacion tipoOperacion)
        {
            CuentaOrigen = cuentaOrigen;
            CuentaDestino = cuentaDestino;
            Fecha = fecha;
            Monto = monto;
            TipoOperacion = tipoOperacion;
        }

        public override string ToString()
        {
            string data = $"Fecha: {Fecha}" + $" Operación: {TipoOperacion} "  + $"Monto: {Monto}\n";
            data += $"Cliente Origen: {CuentaOrigen.Cliente.CUIT}\n";
            data += $"Cliente Destino: {CuentaDestino.Cliente.CUIT}\n";
            return data;
        }

        // Método para mostrar la información de la operación
    }

}
