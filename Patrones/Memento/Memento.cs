using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patrones.Memento
{
    using System;
    using System.Collections.Generic;

    public class Memento
    {
        public int Salud { get; private set; }

        public Memento(int salud)
        {
            Salud = salud;
        }
    }
}
