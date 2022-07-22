using Pharmacy_backend.Domain;
using System.Data;
using System.Data.SqlClient;

namespace Pharmacy_backend.Repositories
{
    public class PharmacyRepository : IPharmacyRepository
    {
        private readonly string _connectionString;

        public PharmacyRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Pharmacy> GetAll()
        {
            List<Pharmacy> pharmacies = new List<Pharmacy>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM [Pharmacy]";

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            pharmacies.Add(new Pharmacy
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                IdBrand = Convert.ToInt32(reader["IdBrand"]),
                                Address = Convert.ToString(reader["Address"]),
                                PhoneNumber = Convert.ToString(reader["PhoneNumber"])
                            });
                        }
                    }
                }
            }

            return pharmacies;
        }

        public int Create(Pharmacy pharmacy)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO Pharmacy (IdBrand, Address, PhoneNumber) 
                                        VALUES (@IdBrand, @Address, @PhoneNumber)";
                    cmd.Parameters.Add("@IdBrand", SqlDbType.Int).Value = pharmacy.IdBrand;
                    cmd.Parameters.Add("@Address", SqlDbType.NVarChar).Value = pharmacy.Address;
                    cmd.Parameters.Add("@PhoneNumber", SqlDbType.NVarChar).Value = pharmacy.PhoneNumber;

                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        public Pharmacy Get(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Pharmacy WHERE [id] = @id";
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Pharmacy
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                IdBrand = Convert.ToInt32(reader["IdBrand"]),
                                Address = Convert.ToString(reader["Address"]),
                                PhoneNumber = Convert.ToString(reader["PhoneNumber"])
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

        public bool CheckId(int id)
        {
            if (Get(id) == null)
                return false;
            return true;
        }

        public int Update(Pharmacy pharmacy)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = @"UPDATE Pharmacy SET IdBrand = @IdBrand, Address = @Address, PhoneNumber = @PhoneNumber 
                                        WHERE [Id] = @Id";
                    cmd.Parameters.Add("@Id", SqlDbType.Int).Value = pharmacy.Id;
                    cmd.Parameters.Add("@IdBrand", SqlDbType.Int).Value = pharmacy.IdBrand;
                    cmd.Parameters.Add("@Address", SqlDbType.NVarChar).Value = pharmacy.Address;
                    cmd.Parameters.Add("@PhoneNumber", SqlDbType.NVarChar).Value = pharmacy.PhoneNumber;
        
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }
    }
}
