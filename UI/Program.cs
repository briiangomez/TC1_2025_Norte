using DAO.Contracts;
using DAO.Factory;
using DAO.Implementations;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Hoy tengo una implementación in memory de mi Dao
            ICustomerRepository customerDao = new DAO.Implementations.Memory.CustomerRepository();

            Console.WriteLine("---------------------------------------------");

            foreach (var item in customerDao.GetAll())
            {
                Console.WriteLine($"id: {item.IdCustomer}, code: {item.Code} - Name: {item.Name}");
            }

            Console.WriteLine("---------------------------------------------");

            customerDao.Insert(new Customer(12, "Nuevo Producto"));

            foreach (var item in customerDao.GetAll())
            {
                Console.WriteLine($"id: {item.IdCustomer}, code: {item.Code} - Name: {item.Name}");
            }

            Console.WriteLine("---------------------------------------------");

            Customer customerById = customerDao.GetByCode(12);

            customerDao.Delete(customerById.IdCustomer);

            foreach (var item in customerDao.GetAll())
            {
                Console.WriteLine($"id: {item.IdCustomer}, code: {item.Code} - Name: {item.Name}");
            }

            Console.WriteLine("---------------------------------------------");
        }
    }
}
