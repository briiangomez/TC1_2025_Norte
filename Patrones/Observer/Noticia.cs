using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patrones.Observer
{
    internal class Noticia
    {
        public string Titulo { get; private set; }
        public string Contenido { get; private set; }
        public Noticia(string titulo, string contenido)
        {
            Titulo = titulo;
            Contenido = contenido;
        }
    }
}
