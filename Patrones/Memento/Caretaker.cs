using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patrones.Memento
{
    internal class Caretaker
    {
        private Stack<Memento> mementos = new Stack<Memento>();
        private Personaje originator;

        public Caretaker(Personaje originator)
        {
            this.originator = originator;
        }

        public void GuardarEstado()
        {
            mementos.Push(originator.CrearMemento());
        }

        public Memento ObtenerUltimoMemento()
        {
            if (mementos.Count > 0)
            {
                return mementos.Pop();
            }
            return null;
        }
        public bool TieneMementos()
        {
            return mementos.Count > 0;
        }
    }
}
