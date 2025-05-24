using Services.Facade.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.BusinessExceptions
{
    public  class ClienteMayorEdadException : Exception
    {
        public ClienteMayorEdadException() : base("El Cliente no es mayor de edad".Traducir())
        {
            
        }
    }
}
