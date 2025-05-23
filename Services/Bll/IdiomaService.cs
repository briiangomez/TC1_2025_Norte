using Services.Dal;
using Services.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Bll
{
    public sealed class IdiomaService
    {
        private readonly static IdiomaService _instance = new IdiomaService();

        public static IdiomaService Current
        {
            get
            {
                return _instance;
            }
        }

        private IdiomaService()
        {
            //Implent here the initialization of your singleton
        }


        public string Traducir(string word)
        {
            try
            {
                return IdiomaRepository.Current.Traducir(word);
            }
            catch (WordNotFoundException ex)
            {
                //Podría aplicar una nueva política
                IdiomaRepository.Current.AgregarDataKey(word);
                //Esto seguramente vaya a una bitácora
                Console.WriteLine(ex.Message);

                return word;
            }
        }

    }

}
