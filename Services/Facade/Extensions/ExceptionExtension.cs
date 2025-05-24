using Services.Domain.ServicesExceptions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Facade.Extensions
{
    public static class ExceptionExtensions
    {
        public static void Handle(this Exception ex)
        {
            var stackTrace = new StackTrace(ex, true);

            // Buscamos el primer frame válido en la pila
            for (int i = 0; i < stackTrace.FrameCount; i++)
            {
                var frame = stackTrace.GetFrame(i);
                var method = frame.GetMethod();
                var declaringType = method?.DeclaringType;
                var assemblyName = declaringType?.Assembly.GetName().Name;

                if (assemblyName != null)
                {
                    // Aquí puedes listar tus nombres reales de ensamblados para UI, BLL, DAL
                    switch (assemblyName)
                    {
                        case "UI":
                            HandleUIException(ex);
                            return;
                        case "BLL":
                            HandleBLLException(ex);
                            return;
                        case "DAO":
                            HandleDALException(ex);
                            return;
                        // Por si quieres manejar otros ensamblados
                        default:
                            // Sigue buscando un frame con un assembly conocido
                            continue;
                    }
                }
            }

            // Si no se detectó ningún assembly conocido, manejamos de forma general
            DefaultHandler(ex);
        }

        private static void HandleUIException(Exception ex)
        {
            Console.WriteLine($"[UI EXCEPTION]: {ex.Message} {ex.Message} {ex.StackTrace}");
            // Aquí puedes mostrar mensaje o log específico para UI
        }

        private static void HandleBLLException(Exception ex)
        {
            Console.WriteLine($"[BLL EXCEPTION]: {ex.Message} {ex.Message} {ex.StackTrace}");
            ////Política en BLL pero de exceptions desde la DAL
            //if (ex.InnerException != null)
            //{
            //    //Aplicar política de envoltura....
            //    throw ex;
            //}


            ////Política de reglas propias del negocio
            ////Política de exceptions propias de mi negocio
            ////ClienteNoExisteException...
            ////Bitacora
            ////Ver bitácora... Severidad, format
            ////throw ex;
            ////? Estoy en un punto donde no tengo ni Exception de Acceso a datos y tampoco tengo una regla de negocio aplicada....
            //// Bug?
        }


        private static void HandleDALException(Exception ex)
        {
            //Bitacora
            //Ver bitácora... Severidad, format
            Console.WriteLine($"[DAL EXCEPTION]: {ex.Message} {ex.Message} {ex.StackTrace}");
            //throw ex;
            // Aquí puedes registrar logs de base de datos o errores críticos
        }

        private static void DefaultHandler(Exception ex)
        {
            Console.WriteLine($"[GENERAL EXCEPTION]: {ex.Message}");
        }
    }

}