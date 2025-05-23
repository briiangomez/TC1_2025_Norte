using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patrones.Memento
{
    internal class Personaje
    {
        public int Velocidad { get; set; }
        public int Salud { get; private set; }

        private int golpeContador = 0;

        public string Nombre { get; set; }

        private Caretaker caretaker;

        public Personaje(int velocidad, string nombre)
        {
            Velocidad = velocidad;
            Salud = 100;
            Nombre = nombre;
        }

        public void DarGolpe(Personaje personajeObjetivo, TipoGolpe tipoGolpe)
        {
            personajeObjetivo.RecibirGolpe(tipoGolpe);

            golpeContador++;

            // Recuperar salud si se han dado 5 golpes consecutivos
            if (golpeContador == 5)
            {
                RecuperarSalud();
                golpeContador = 0; // Reiniciar contador
            }
        }

        private void RecibirGolpe(TipoGolpe tipoGolpe)
        {
            //Guardar el estado actual antes de recibir el golpe
            caretaker.GuardarEstado();

            if (tipoGolpe == TipoGolpe.Debil) 
                Salud -= 5;
            else if (tipoGolpe == TipoGolpe.Intermedio) 
                Salud -= 10;
            else if (tipoGolpe == TipoGolpe.Fuerte) 
                Salud -= 20;

            if (Salud < 0) Salud = 0;  
        }

        public Memento CrearMemento()
        {
            return new Memento(Salud);
        }

        public void RecuperarSalud()
        {
            if (caretaker.TieneMementos())
            {
                Memento memento = caretaker.ObtenerUltimoMemento();
                RestaurarMemento(memento);
                Console.WriteLine("Salud recuperada a: " + Salud);
            }
        }

        public void RestaurarMemento(Memento memento)
        {
            Salud = memento.Salud;
        }

        public void MostrarEstado()
        {
            Console.WriteLine($"Nombre: {Nombre}, Velocidad: {Velocidad}, Salud: {Salud}");
        }
        public void EstablecerCaretaker(Caretaker caretaker)
        {
            this.caretaker = caretaker;
        }
    }

    internal enum TipoGolpe
    {
        Debil = 1,
        Intermedio = 2,
        Fuerte = 3,
    }
}
