using Services.Domain.Exceptions;
using Services.DomainModel.Exceptions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Dal
{

    public sealed class IdiomaRepository
    {
        #region Singleton
        private readonly static IdiomaRepository _instance = new IdiomaRepository();

        public static IdiomaRepository Current
        {
            get
            {
                return _instance;
            }
        }

        private IdiomaRepository()
        {
            //Implent here the initialization of your singleton
        }
        #endregion

        private static string folderPath = ConfigurationManager.AppSettings["IdiomaFolderPath"];

        private static string fileName = ConfigurationManager.AppSettings["IdiomaFileName"];

        private static string path = default;
        static IdiomaRepository()
        {
            path = Path.Combine(folderPath, fileName);
        }

        public string Traducir(string word)
        {
            try
            {
                string cultura = Thread.CurrentThread.CurrentCulture.Name;

                string localPath = $"{path}.{cultura}";

                using (StreamReader sr = new StreamReader(localPath))
                {
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();

                        string[] strings = line.Split('=');
                        string key = strings[0];
                        string value = strings[1];

                        if (key.ToLower() == word.ToLower())
                        {
                            return value;
                        }
                    }
                }
                throw new WordNotFoundException();
            }
            catch (Exception ex)
            {
                //Tratamiento de excepciones genéricas.
                Console.WriteLine(ex.Message);
                throw;
            }                  
        }

        public void AgregarDataKey(string key)
        {

        }

    }

}
