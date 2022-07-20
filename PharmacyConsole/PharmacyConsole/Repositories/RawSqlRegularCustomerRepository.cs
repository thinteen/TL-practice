using System.Data;
using System.Data.SqlClient;
using System.Xml.Linq;
using BlogsApp.Models;

namespace BlogsApp.Repositories
{
    public class RawSqlRegularCustomerRepository : IRegularCustomerRepository
    {
        private readonly string _connectionString;

        public RawSqlRegularCustomerRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public IReadOnlyList<RegularCustomer> GetAll()
        {
            var result = new List<RegularCustomer>();

            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            using SqlCommand sqlCommand = connection.CreateCommand();
            sqlCommand.CommandText = "select [Id], [IdBrand], [FullName], [PhoneNumber], [CustomerCardNumber], [AccumulatedPoints] from [RegularCustomer]";

            using SqlDataReader reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                result.Add(new RegularCustomer(
                    Convert.ToInt32(reader["Id"]),
                    Convert.ToInt32(reader["IdBrand"]),
                    Convert.ToString(reader["FullName"]),
                    Convert.ToString(reader["PhoneNumber"]),
                    Convert.ToString(reader["CustomerCardNumber"]),
                    Convert.ToInt32(reader["AccumulatedPoints"])
                    ));
            }

            return result;
        }
        public RegularCustomer GetById(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            using SqlCommand sqlCommand = connection.CreateCommand();
            sqlCommand.CommandText = "select [Id], [IdBrand], [FullName], [PhoneNumber], [CustomerCardNumber], [AccumulatedPoints] from [RegularCustomer] where [Id] = @id";
            sqlCommand.Parameters.Add("@id", SqlDbType.Int).Value = id;

            using SqlDataReader reader = sqlCommand.ExecuteReader();
            if (reader.Read())
            {
                return new RegularCustomer(
                    Convert.ToInt32(reader["Id"]),
                    Convert.ToInt32(reader["IdBrand"]),
                    Convert.ToString(reader["FullName"]),
                    Convert.ToString(reader["PhoneNumber"]),
                    Convert.ToString(reader["CustomerCardNumber"]),
                    Convert.ToInt32(reader["AccumulatedPoints"])
                    );
            }
            else
            {
                return null;
            }
        }

        public void Delete(RegularCustomer regularCustomer)
        {
            if (regularCustomer == null)
            {
                throw new ArgumentNullException(nameof(regularCustomer));
            }

            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            using SqlCommand sqlCommand = connection.CreateCommand();
            sqlCommand.CommandText = "delete [RegularCustomer] where [Id] = @id";
            sqlCommand.Parameters.Add("@id", SqlDbType.Int).Value = regularCustomer.Id;
            sqlCommand.ExecuteNonQuery();
        }
    }
}