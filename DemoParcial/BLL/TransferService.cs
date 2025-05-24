using DemoParcial.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading.Tasks;

namespace DemoParcial.BLL
{
    public class TransferService
    {
        public void Transferir(Cuenta cuentaOrigen, Cuenta cuentaDestino, decimal monto)
        {
            if (cuentaOrigen == null) throw new ArgumentNullException(nameof(cuentaOrigen));
            if (cuentaDestino == null) throw new ArgumentNullException(nameof(cuentaDestino));
            if (monto <= 0) throw new ArgumentException("El monto debe ser mayor a cero.", nameof(monto));
            if (cuentaOrigen.Saldo < monto) throw new InvalidOperationException("Saldo insuficiente en la cuenta origen.");

            bool mismoTitular = cuentaOrigen.Cliente.CUIT == cuentaDestino.Cliente.CUIT;
            bool esConversion = cuentaOrigen.GetType() != cuentaDestino.GetType();

            if (esConversion && !mismoTitular)
                throw new InvalidOperationException("Conversiones sólo permitidas entre cuentas del mismo titular.");

            //Comienzo de la transacción

            //begin tran
            cuentaOrigen.Retirar(monto);

            // Despacho dinámico
            Operacion operacion = ProcesarTransferencia((dynamic)cuentaOrigen, (dynamic)cuentaDestino, monto);

            Console.WriteLine(operacion);

            //Ir al repositorio
            //1) Actualizar la cuenta origen
            //2) Actualizar la cuenta destino
            //3) Insertar la operacion
            //commit tran

            // Guardar operación, persistencia, etc.
        }

        private Operacion ProcesarTransferencia(CajaAhorro origen, CajaAhorro destino, decimal monto)
        {
            destino.Depositar(monto);
            return new Operacion(origen, destino, DateTime.Now, monto, TipoOperacion.TransferenciaATerceros);
        }

        private Operacion ProcesarTransferencia(MonederoBTC origen, MonederoBTC destino, decimal monto)
        {
            destino.Depositar(monto);
            return new Operacion(origen, destino, DateTime.Now, monto, TipoOperacion.TransferenciaATerceros);
        }

        private Operacion ProcesarTransferencia(CajaAhorro origen, MonederoBTC destino, decimal monto)
        {
            decimal convertido = ConvertirPesosABTC(monto);
            destino.Depositar(convertido);
            return new Operacion(origen, destino, DateTime.Now, monto, TipoOperacion.Conversion);
        }

        private Operacion ProcesarTransferencia(MonederoBTC origen, CajaAhorro destino, decimal monto)
        {
            decimal convertido = ConvertirBTCAPesos(monto);
            destino.Depositar(convertido);
            return new Operacion(origen, destino, DateTime.Now, monto, TipoOperacion.Conversion);
        }

        // Exception si no hay sobrecarga adecuada
        private void ProcesarTransferencia(Cuenta origen, Cuenta destino, decimal monto)
        {
            throw new InvalidOperationException($"No se soporta transferencia de {origen.GetType().Name} a {destino.GetType().Name}");
        }

        private decimal ConvertirPesosABTC(decimal montoPesos) => montoPesos * 0.000000008338m;
        private decimal ConvertirBTCAPesos(decimal montoBtc) => montoBtc * 119928832m;
    }
}
