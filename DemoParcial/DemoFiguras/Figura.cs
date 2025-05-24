using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoParcial.DemoFiguras
{
    interface Figura
    {
        void Colisionar(dynamic figura);

        //Si se desea, establacer métodos para implementación obligada
        //void ColisionarCon(Circulo circulo);
    }
}
