using System.Data;
using System.Data.SqlClient;
using System.Xml.Linq;
using BlogsApp.Models;

namespace BlogsApp.Repositories
{
    public class RawSqlBrandRepository : IBrandRepository
    {
        private readonly string _connectionString;

        public RawSqlBrandRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IReadOnlyList<Brand> GetAll()
        {
            var result = new List<Brand>();

            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            using SqlCommand sqlCommand = connection.CreateCommand();
            sqlCommand.CommandText = "select [Id], [Name] from [Brand]";

            using SqlDataReader reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                result.Add(new Brand(
                    Convert.ToInt32(reader["Id"]),
                    Convert.ToString(reader["Name"])
                    ));
            }

            return result;
        }
    }
}