using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patrones.Observer
{
    internal interface IObservador
    {
        void Actualizar(Noticia noticia);
    }
}
