using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patrones.Observer
{
    internal class Suscriptor : IObservador
    {
        public string Nombre { get; private set; }
        public Suscriptor(string nombre)
        {
            Nombre = nombre;
        }
        public void Actualizar(Noticia noticia)
        {
            Console.WriteLine($"Notificación para {Nombre}: Nueva noticia publicada - {noticia.Titulo}");
        }
    }
}
