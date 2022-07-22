using Pharmacy_backend.Domain;
using System.Data;
using System.Data.SqlClient;

namespace Pharmacy_backend.Repositories
{
    public class MedicineRepository : IMedicineRepository
    {
        private readonly string _connectionString;

        public MedicineRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Medicine> GetAll()
        {
            List<Medicine> medicines = new List<Medicine>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM [Medicine]";

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            medicines.Add(new Medicine
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Name = Convert.ToString(reader["Name"]),
                                Price = Convert.ToDecimal(reader["Price"])
                            });
                        }
                    }
                }
            }

            return medicines;
        }

        public Medicine Get(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Medicine WHERE [id] = @id";
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Medicine
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Name = Convert.ToString(reader["Name"]),
                                Price = Convert.ToDecimal(reader["Price"])
                            };
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
        }

        public void Delete(Medicine medicine)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM Medicine WHERE [id] = @id";
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = medicine.Id;

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<QuantityMedicineInPharmacy> GetQuantityMedicineInPharmacyByName(string name)
        {
            List<QuantityMedicineInPharmacy> result = new List<QuantityMedicineInPharmacy>();

            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            using SqlCommand sqlCommand = connection.CreateCommand();
            sqlCommand.CommandText = @"SELECT b.Name 'BrandName', p.Address, m.Name 'MedicineName', pm.Quantity, m.Price
                                       FROM Brand b
                                       INNER JOIN Pharmacy p ON b.Id = p.IdBrand
                                       INNER JOIN PharmacyMedicine pm ON p.Id = pm.IdPharmacy
                                       INNER JOIN Medicine m ON m.Id = pm.IdMedicine
                                       WHERE m.Name = @name";
            sqlCommand.Parameters.Add("@name", SqlDbType.NVarChar, 50).Value = name;

            using SqlDataReader reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                result.Add(new QuantityMedicineInPharmacy
                {
                    BrandName = Convert.ToString(reader["BrandName"]),
                    Address = Convert.ToString(reader["Address"]),
                    MedicineName = Convert.ToString(reader["MedicineName"]),
                    Quantity = Convert.ToInt32(reader["Quantity"]),
                    Price = Convert.ToDecimal(reader["Price"])
                });
            }

            return result;
        }


    }
}
