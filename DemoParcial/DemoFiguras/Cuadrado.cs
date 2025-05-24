using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoParcial.DemoFiguras
{
    internal class CuadradoFigura : Figura
    {
        public void Colisionar(dynamic figura)
        {
            ColisionarCon(figura);
        }

        private void ColisionarCon(CuadradoFigura cuadrado)
        {
            Console.WriteLine("Soy un cuadrado y estoy colisionando con un cuadrado");
        }

        private void ColisionarCon(CirculoFigura circulo)
        {
            Console.WriteLine("Soy un cuadrado y estoy colisionando con un círculo");
        }

        private void ColisionarCon(Figura figura)
        {            
            throw new Exception($"No se encuentra implementación para este tipo concreto para {figura.GetType().Name}");
        }        
    }
}
