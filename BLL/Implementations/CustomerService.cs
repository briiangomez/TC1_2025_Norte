﻿using BLL.BusinessExceptions;
using BLL.Contracts;
using DAO.Factory;
using Domain.Models;
using Services.Facade.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Implementations
{
    public class CustomerService : ICustomerService
    {
        public void Delete(Guid id)
        {

            ///Aqui deberia aplicar previamente las reglas de negocio...

            Repository.GetCustomerInstance().Delete(id);
        }

        public bool Exists(Guid id)
        {
            return Repository.GetCustomerInstance().Exists(id);
        }

        public List<Customer> GetAll()
        {
            try
            {
                throw new ClienteMayorEdadException();
                return Repository.GetCustomerInstance().GetAll();


            }
            catch (ClienteMayorEdadException ex)
            {
                ///aplica politica de excepciones
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public Customer GetByCode(int code)
        {
            throw new NotImplementedException();
        }

        public Customer GetById(Guid id)
        {
            return Repository.GetCustomerInstance().GetById(id);
        }

        public Customer GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public void Insert(Customer entity)
        {
            Repository.GetCustomerInstance().Insert(entity);
        }

        public void Update(Customer entity)
        {
            throw new NotImplementedException();
        }
    }
}
