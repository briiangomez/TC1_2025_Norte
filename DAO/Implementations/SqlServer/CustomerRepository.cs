using DAO.Contracts;
using DAO.Helpers;
using DAO.Implementations.SqlServer.Adapters;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Implementations.SqlServer
{
    public sealed class CustomerRepository : ICustomerRepository
    {

        #region Statements
        private string InsertStatement
        {
            get => "DECLARE @NewID TABLE (IdCustomer uniqueidentifier); " +
                   "INSERT INTO [dbo].[Customer] (Name) " +
                   "OUTPUT INSERTED.IdCustomer INTO @NewID " +
                   "VALUES (@Name);" +
                   "SELECT IdCustomer FROM @NewID;";
        }

        private string UpdateStatement
        {
            get => "UPDATE [dbo].[Customer] SET (Name,Code) WHERE IdCustomer = @IdCustomer";
        }

        private string DeleteStatement
        {
            get => "DELETE FROM [dbo].[Customer] WHERE IdCustomer = @IdCustomer";
        }

        private string SelectOneStatement
        {
            get => "SELECT IdCustomer, Name,Code FROM [dbo].[Customer] WHERE IdCustomer = @IdCustomer";
        }

        private string SelectAllStatement
        {
            get => "SELECT IdCustomer, Name,Code FROM [dbo].[Customer]";
        }
        #endregion


        private readonly static CustomerRepository  _instance = new CustomerRepository ();

		public static CustomerRepository  Current
		{
			get
			{
				return _instance;
			}
		}

		public CustomerRepository()
		{
			//Implent here the initialization of your singleton
		}

        public Customer GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public Customer GetByCode(int code)
        {
            throw new NotImplementedException();
        }

        public List<Customer> GetAll()
        {
            List<Customer> listCustomers = new List<Customer>();

            using (SqlDataReader reader = SqlHelper.ExecuteReader(SelectAllStatement,
                                                    CommandType.Text,
                                                    new SqlParameter[] { }))
            {

                //Mientras tenga un registro para la lectura...avanzo
                while (reader.Read())
                {
                    //Leemos cada tupla de la tabla
                    object[] data = new object[reader.FieldCount];
                    reader.GetValues(data);

                    Customer customer = CustomerAdapter.Current.Get(data);
                    listCustomers.Add(customer);
                }
            }

            return listCustomers;
        }

        public Customer GetById(Guid id)
        {
            Customer customer = default;

            using (SqlDataReader reader = SqlHelper.ExecuteReader(SelectOneStatement,
                                                 CommandType.Text,
                                                 new SqlParameter[] {
                                                     new SqlParameter("@IdCustomer", id) }))
            {

                //Hacemos la lectura de un solo registro
                if (reader.Read())
                {
                    //Leemos cada tupla de la tabla
                    object[] data = new object[reader.FieldCount];
                    reader.GetValues(data);

                    customer = CustomerAdapter.Current.Get(data);
                }
            }

            return customer;
        }

        public void Insert(Customer entity)
        {
            //Para Stored procedures se puede utilizar SELECT SCOPE_IDENTITY()
            object returnValue = SqlHelper.ExecuteScalar(InsertStatement, CommandType.Text,
              new SqlParameter[] { new SqlParameter("@Name", entity.Name), new SqlParameter("@Code",entity.Code) });

            entity.IdCustomer = Guid.Parse(returnValue.ToString());

        }

        public void Update(Customer entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public bool Exists(Guid id)
        {
            throw new NotImplementedException();
        }
    }

}
