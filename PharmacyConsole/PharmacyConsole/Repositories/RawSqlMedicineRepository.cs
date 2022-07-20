using System.Data;
using System.Data.SqlClient;
using System.Xml.Linq;
using BlogsApp.Models;

namespace BlogsApp.Repositories
{
    public class RawSqlMedicineRepository : IMedicineRepository
    {
        private readonly string _connectionString;

        public RawSqlMedicineRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IReadOnlyList<Medicine> GetAll()
        {
            var result = new List<Medicine>();

            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            using SqlCommand sqlCommand = connection.CreateCommand();
            sqlCommand.CommandText = "select [Id], [Name], [Price] from [Medicine]";

            using SqlDataReader reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                result.Add(new Medicine(
                    Convert.ToInt32(reader["Id"]),
                    Convert.ToString(reader["Name"]),
                    Convert.ToInt32(reader["Price"])
                    ));
            }

            return result;
        }

        public Medicine GetByName(string name)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            using SqlCommand sqlCommand = connection.CreateCommand();
            sqlCommand.CommandText = "select [Id], [Name], [Price] from [Medicine] where [Name] = @name";
            sqlCommand.Parameters.Add("@name", SqlDbType.VarChar, 50).Value = name;

            using SqlDataReader reader = sqlCommand.ExecuteReader();
            if (reader.Read())
            {
                return new Medicine(
                    Convert.ToInt32(reader["Id"]),
                    Convert.ToString(reader["Name"]),
                    Convert.ToInt32(reader["Price"])
                    );
            }
            else
            {
                return null;
            }
        }

        public IReadOnlyList<QuantityMedicineInPharmacy> GetQuantityMedicineInPharmacyByName(string name)
        {
            var result = new List<QuantityMedicineInPharmacy>();

            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            using SqlCommand sqlCommand = connection.CreateCommand();
            sqlCommand.CommandText = @"select b.Name 'BrandName', p.Address, m.Name 'MedicineName', pm.Quantity, m.Price
                                       from Brand b
                                       inner join Pharmacy p on b.Id = p.IdBrand
                                       inner join PharmacyMedicine pm on p.Id = pm.IdPharmacy
                                       inner join Medicine m on m.Id = pm.IdMedicine
                                       where m.Name = @name";
            sqlCommand.Parameters.Add("@name", SqlDbType.VarChar, 50).Value = name;

            using SqlDataReader reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                result.Add( new QuantityMedicineInPharmacy(
                    Convert.ToString(reader["BrandName"]),
                    Convert.ToString(reader["Address"]),
                    Convert.ToString(reader["MedicineName"]),
                    Convert.ToInt32(reader["Quantity"]),
                    Convert.ToInt32(reader["Price"])
                    ) );
            }

            return result;
        }

        public IReadOnlyList<NumberOfVarietiesOfMedicines> GetNumberOfVarietiesOfMedicines()
        {
            var result = new List<NumberOfVarietiesOfMedicines>();

            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            using SqlCommand sqlCommand = connection.CreateCommand();
            sqlCommand.CommandText = "select IdPharmacy, Count(IdMedicine) 'NumberOfVarietiesOfMedicines' from PharmacyMedicine group by IdPharmacy";

            using SqlDataReader reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                result.Add(new NumberOfVarietiesOfMedicines(
                    Convert.ToInt32(reader["IdPharmacy"]),
                    Convert.ToInt32(reader["NumberOfVarietiesOfMedicines"])
                    ));
            }

            return result;
        }
    }
}