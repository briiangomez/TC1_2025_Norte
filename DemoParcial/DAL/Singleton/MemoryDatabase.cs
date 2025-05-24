using DemoParcial.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoParcial.DAL.Singleton
{

	public sealed class MemoryDatabase
    {
        public List<Cliente> Clientes { get; } = new List<Cliente>();
        public List<Operacion> Operaciones { get; } = new List<Operacion>();

        private readonly static MemoryDatabase _instance = new MemoryDatabase();

		public static MemoryDatabase Current
		{
			get
			{
				return _instance;
			}
		}

		private MemoryDatabase()
		{
			//Implent here the initialization of your singleton
		}
	}

}
