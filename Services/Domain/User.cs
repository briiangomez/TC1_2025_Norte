using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Domain
{

    public sealed class UserTest
    {
        public int Legajo { get; set; }

        private readonly static UserTest _instance = new UserTest();

        public static UserTest Current
        {
            get
            {
                return _instance;
            }
        }

        private UserTest()
        {
            //Implent here the initialization of your singleton
        }
    }


    public class User
    {
        #region Propiedades
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public bool enable { get; set; }

        /// <summary>
        /// Instancia única dentro de la propia clase
        /// </summary>
        private static User instance;

        //Para permitir interbloqueos
        private static object instanceLock = new object();

        #endregion

        #region Constructores

        /// <summary>
        /// Constructor privado
        /// </summary>
        private User()
        {
            Console.WriteLine("Construyendo el objeto User");            
        }

        #endregion

        #region Comportamiento

        public static User GetInstance()
        {
            //th2
            //th1
            if (instance == null)
            {
                //th2
                //th1
                lock (instanceLock)
                {
                    //th2
                    //th1
                    if (instance == null)
                    {
                        instance = new User();
                    }
                }
                //th1 liberó el interbloqueo
                //th2 se llevó la misma instancia que th1
            }
            return instance; //th1 //th2
        }

        public void IsEnabled()
        {
            Console.WriteLine($"Estoy en estado activo: {enable}");
        }

        #endregion

    }
}
