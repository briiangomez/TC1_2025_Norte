using BLL.Contracts;
using BLL.Implementations;
using DAO.Contracts;
using DAO.Factory;
using DAO.Implementations;
using Domain.Models;
using Services.Facade.Extensions;
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
            ICustomerService customerDao = new CustomerService();

            try
            {


                Console.WriteLine("---------------------------------------------");

                foreach (var item in customerDao.GetAll())
                {
                    Console.WriteLine($"id: {item.IdCustomer}, code: {item.Code} - Name: {item.Name}");
                }

                Console.WriteLine("---------------------------------------------");

                throw new Exception("Error en UI");
            }
            catch (Exception ex)
            {
                ex.Handle();
            }

            //Hoy tengo una implementación in memory de mi Dao
            //ICustomerRepository customerDao = new DAO.Implementations.Memory.CustomerRepository();

            //Llamo a la factory...
            //ICustomerRepository customerDao = Repository.GetCustomerInstance();

            



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
