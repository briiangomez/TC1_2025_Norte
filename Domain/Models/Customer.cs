using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Enums;

namespace Domain.Models
{
    /// <summary>
    /// Esta clase se utiliza para modelar un cliente...
    /// </summary>
    public class Customer
    {
        public Guid IdCustomer { get; set; }
        public int Code { get; set; }

        public string Name { get; set; }

        /// <summary>
        /// Constructor con todos los argumentos...
        /// </summary>
        /// <param name="code">Param 1</param>
        /// <param name="name">Param 2</param>
        /// 

        public Customer(int code, string name)
        {
            Code = code;
            Name = name;
        }
        public Customer()
        {
            
        }

        public Customer(Guid idCustomer, int code, string name)
        {
            IdCustomer = idCustomer;
            Code = code;
            Name = name;
        }
    }
}
