using Patrones.Memento;
using Patrones.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patrones
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("EJERCICIO MOTIVACIÓN MEMENTO");
            Memento();
            Console.WriteLine("EJERCICIO MOTIVACIÓN OBSERVER");
            Observer();
        }

        private static void Observer()
        {
            // Crear revistas
            Revista revistaPesca = new Revista("Revista de Pesca");
            Revista revistaDeporte = new Revista("Revista de Deporte");
            // Crear suscriptores
            Suscriptor suscriptor1 = new Suscriptor("Juan");
            Suscriptor suscriptor2 = new Suscriptor("Maria");
            // Suscribir usuarios a revistas
            revistaPesca.Suscribir(suscriptor1);
            revistaDeporte.Suscribir(suscriptor2);
            revistaDeporte.Suscribir(suscriptor1); // Juan también se suscribe a la revista de deporte
                                                   // Publicar noticias
            revistaPesca.PublicarNoticia("Nuevas técnicas de pesca", "Aprende a pescar en el río Reconquista...");
            revistaDeporte.PublicarNoticia("Resultados de la copa del mundo 2026", "Los resultados de la última jornada...");
        }

        private static void Memento()
        {
            //Crear el Originator
            Personaje personajeGanador = new Personaje(7, "Ganador");
            Personaje personajeObjetivo = new Personaje(8, "Objetivo");

            //Crear el Caretaker y pasarle el Originator
            Caretaker caretakerGanador = new Caretaker(personajeGanador);
            Caretaker caretakerObjetivo = new Caretaker(personajeObjetivo);

            //Establecer el Caretaker en la Persona
            personajeGanador.EstablecerCaretaker(caretakerGanador);
            personajeObjetivo.EstablecerCaretaker(caretakerObjetivo);

            //Estado inicial antes de iniciar la lucha cuerpo a cuerpo
            personajeGanador.MostrarEstado();
            personajeObjetivo.MostrarEstado();

            //Personaje objetivo le quita salud al ganador
            personajeObjetivo.DarGolpe(personajeGanador, TipoGolpe.Fuerte);
            personajeGanador.MostrarEstado();

            // Recibir golpes
            personajeGanador.DarGolpe(personajeObjetivo, TipoGolpe.Debil); // Golpe débil
            personajeObjetivo.MostrarEstado();
            personajeGanador.DarGolpe(personajeObjetivo, TipoGolpe.Intermedio); // Golpe intermedio
            personajeObjetivo.MostrarEstado();
            personajeGanador.DarGolpe(personajeObjetivo, TipoGolpe.Fuerte); // Golpe fuerte
            personajeObjetivo.MostrarEstado();

            // Recibir más golpes para activar la recuperación
            personajeGanador.DarGolpe(personajeObjetivo, TipoGolpe.Debil);
            personajeObjetivo.MostrarEstado();
            personajeGanador.DarGolpe(personajeObjetivo, TipoGolpe.Debil);  //Esto debería activar la recuperación
            personajeGanador.MostrarEstado(); // Debería mostrar la salud recuperada del personaje ganador
        }
    }
}
