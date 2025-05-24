using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoParcial.BLL
{
    using System;

    public abstract class Forma
    {
        public abstract void ColisionarCon(dynamic otra);
    }

    public class Circulo : Forma
    {
        public override void ColisionarCon(dynamic otra)
        {
            // Usamos dynamic para permitir el doble dispatch
            otra.ColisionarConCirculo(this);
        }

        public void ColisionarConCirculo(Circulo circulo)
        {
            Console.WriteLine("Colisión entre dos círculos.");
        }

        public void ColisionarConCuadrado(Cuadrado cuadrado)
        {
            Console.WriteLine("Colisión entre un círculo y un cuadrado.");
        }
    }

    public class Cuadrado : Forma
    {
        public override void ColisionarCon(dynamic otra)
        {
            // Usamos dynamic para permitir el doble dispatch
            otra.ColisionarConCuadrado(this);
        }

        public void ColisionarConCirculo(Circulo circulo)
        {
            Console.WriteLine("Colisión entre un cuadrado y un círculo.");
        }

        public void ColisionarConCuadrado(Cuadrado cuadrado)
        {
            Console.WriteLine("Colisión entre dos cuadrados.");
        }
    }

    public class Test
    {
        public void Run()
        {
            Forma circulo1 = new Circulo();
            Forma circulo2 = new Circulo();
            Forma cuadrado1 = new Cuadrado();

            // Simulamos colisiones
            circulo1.ColisionarCon(circulo2); // Salida: Colisión entre dos círculos.
            circulo1.ColisionarCon(cuadrado1); // Salida: Colisión entre un círculo y un cuadrado.
            cuadrado1.ColisionarCon(circulo1); // Salida: Colisión entre un cuadrado y un círculo.
            cuadrado1.ColisionarCon(new Cuadrado()); // Salida: Colisión entre dos cuadrados.
        }
    }
}
