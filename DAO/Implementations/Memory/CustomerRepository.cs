using DAO.Contracts;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Implementations.Memory
{
    public sealed class CustomerRepository : ICustomerRepository
    {
        #region singleton
        private readonly static CustomerRepository _instance = new CustomerRepository();

        public static CustomerRepository Current
        {
            get
            {
                return _instance;
            }
        }

        public CustomerRepository()
        {
            _list = new List<Customer>();

            for (int i = 1; i <= 10; i++)
            {
                Customer customer = new Customer(i + 1, i.ToString());
                customer.IdCustomer = Guid.NewGuid();
                _list.Add(customer);
            }
        }
        #endregion

        private static List<Customer> _list;

        public void Insert(Customer obj)
        {
            //Qué debería hacer para agregar un customer?
            //Ver si existe? -> Lo validamos en negocio si es que yo
            //envío el id

            //Simulamos que el id es auto-incremental
            obj.IdCustomer = Guid.NewGuid();
            _list.Add(obj);
        }

        public List<Customer> GetAll()
        {
            return _list;
        }

        public Customer GetById(Guid idCustomer)
        {
            //Estructurado, más adelante veremos funcional con Linq
            Customer customer = default;

            foreach (var item in _list)
            {
                if (item.IdCustomer == idCustomer)
                {
                    customer = item;
                    break;
                }
            }

            return customer;
        }

        public void Delete(Guid idCustomer)
        {
            _list.Remove(GetById(idCustomer));
        }

        public void Update(Customer obj)
        {
            Customer customer = GetById(obj.IdCustomer);

            customer.Code = obj.Code;
            customer.Name = obj.Name;

        }



        public Customer GetByCode(int code)
        {
            //Estructurado, más adelante veremos funcional con Linq
            Customer customer = default;

            foreach (var item in _list)
            {
                if (item.Code == code)
                {
                    customer = item;
                    break;
                }
            }

            return customer;
        }

        Customer ICustomerRepository.GetByName(string name)
        {
            //Estructurado, más adelante veremos funcional con Linq
            Customer customer = default;

            foreach (var item in _list)
            {
                if (item.Name == name)
                {
                    customer = item;
                    break;
                }
            }

            return customer;
        }


        public bool Exists(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
