using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using DemoParcial.BLL;
using DemoParcial.BLL.UnitOfWork;
using DemoParcial.DAL.Implementations;
using DemoParcial.DomainModel;

namespace ExchangeApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var uow = new InMemoryUnitOfWork();

            // Crear cuentas y cliente
            var cliente = new Cliente("20312437210", "Pepe");

            var cuenta1 = new CajaAhorro(Guid.NewGuid(),"1234567890123456789000");
            cuenta1.Depositar(1000000);
            var cuenta2 = new MonederoBTC(Guid.NewGuid(), "YYYY-YYYY");

            uow.Cuentas.Add(cuenta1);
            uow.Cuentas.Add(cuenta2);

            cliente.AgregarCuenta(cuenta1);
            cliente.AgregarCuenta(cuenta2);

            var service = new TransferService();
            service.Transferir(cuenta1, cuenta2, 50000);

            service.Transferir(cuenta1, cuenta2, 5000000);

            service.Transferir(cuenta1, cuenta2, 500000000);

            // Verificar
            var operacionRepo = (OperacionRepository)uow.Operaciones;
            foreach (var op in operacionRepo.GetAll())
            {
                Console.WriteLine(op);
            }


            //TransferService service = new TransferService();

            //Cliente cliente = new Cliente("20312437210", "Pepe");
            //CajaAhorro cajaAhorro = new CajaAhorro("1234567890123456789000");
            //cajaAhorro.Depositar(1000000);
            //cliente.AgregarCuenta(cajaAhorro);

            //MonederoBTC mon = new MonederoBTC("YYYY-YYYY");
            //cliente.AgregarCuenta(mon);

            //Console.WriteLine("Antes de convertir de $ a BTC");
            //Console.WriteLine($"Caja Ahorro $: {cajaAhorro.Saldo}");
            //Console.WriteLine($"Monedero BTC: {mon.Saldo}");

            //service.Transferir(cajaAhorro, mon, 10000);

            //Console.WriteLine("Luego de hacer la conversión");
            //Console.WriteLine($"Caja Ahorro $: {cajaAhorro.Saldo}");
            //Console.WriteLine($"Monedero BTC: {mon.Saldo}");

            //service.Transferir(mon, cajaAhorro, (decimal)0.00008338);

            //Console.WriteLine("Luego de hacer la conversión a saldo inicial");
            //Console.WriteLine($"Caja Ahorro $: {cajaAhorro.Saldo}");
            //Console.WriteLine($"Monedero BTC: {mon.Saldo}");

            //Cliente cliente2 = new Cliente("27312437210", "María");
            //CajaAhorro cajaAhorro2 = new CajaAhorro("6664567890123456789000");
            //MonederoBTC monederoBTC2 = new MonederoBTC("FF");
            //monederoBTC2.Depositar(1);

            //cliente2.AgregarCuenta(cajaAhorro2);
            //cliente2.AgregarCuenta(monederoBTC2);

            //Console.WriteLine("Antes de transferir de $ a $");
            //Console.WriteLine($"Caja Ahorro 1 $: {cajaAhorro.Saldo}");
            //Console.WriteLine($"Caja Ahorro 2 $: {cajaAhorro2.Saldo}");

            //service.Transferir(cajaAhorro, cajaAhorro2, 50000);

            //Console.WriteLine("Después de transferir de $ a $");
            //Console.WriteLine($"Caja Ahorro 1 $: {cajaAhorro.Saldo}");
            //Console.WriteLine($"Caja Ahorro 2 $: {cajaAhorro2.Saldo}");

            //Console.WriteLine("Antes de transferir de BTC a BTC");
            //Console.WriteLine($"BTC 1 $: {monederoBTC2.Saldo}");
            //Console.WriteLine($"BTC 2 $: {mon.Saldo}");

            //service.Transferir(monederoBTC2, mon, (decimal)0.5);

            //Console.WriteLine("Después de transferir de BTC a BTC");
            //Console.WriteLine($"BTC 1 $: {monederoBTC2.Saldo}");
            //Console.WriteLine($"BTC 2 $: {mon.Saldo}");

            Console.Read();
        }


    }
}

