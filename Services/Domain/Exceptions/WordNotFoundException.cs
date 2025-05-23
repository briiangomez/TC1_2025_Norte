using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Services.Domain.Exceptions
{
    /// <summary>
    /// Se pueden aplicar políticas de excepciones a nivel Objeto (Tipo)
    /// </summary>
    internal class WordNotFoundException : Exception
    {
        public int CodigoPersonalizado { get; }

        public WordNotFoundException() : base("Palabra no encontrada")
        {
            this.Source = "?";
            this.HelpLink = "?";
            this.CodigoPersonalizado = 10;

            //Envío un correo...
        }
    }
}
