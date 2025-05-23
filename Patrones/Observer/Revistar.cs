using Patrones.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patrones.Observer
{
    internal class Revista
    {
        private List<IObservador> suscriptores = new List<IObservador>();
        public string Nombre { get; private set; }
        public Revista(string nombre)
        {
            Nombre = nombre;
        }

        public void Suscribir(IObservador observador)
        {
            suscriptores.Add(observador);
        }
        public void Desuscribir(IObservador observador)
        {
            suscriptores.Remove(observador);
        }
        public void Notificar(Noticia noticia)
        {
            foreach (var suscriptor in suscriptores)
            {
                suscriptor.Actualizar(noticia);
            }
        }
        public void PublicarNoticia(string titulo, string contenido)
        {
            Noticia noticia = new Noticia(titulo, contenido);
            Notificar(noticia);
        }
    }
}
