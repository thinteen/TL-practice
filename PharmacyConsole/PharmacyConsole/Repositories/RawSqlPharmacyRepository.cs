using System.Data;
using System.Data.SqlClient;
using System.Xml.Linq;
using BlogsApp.Models;

namespace BlogsApp.Repositories
{
    public class RawSqlPharmacyRepository : IPharmacyRepository
    {
        private readonly string _connectionString;

        public RawSqlPharmacyRepository( string connectionString )
        {
            _connectionString = connectionString;
        }

        public IReadOnlyList<Pharmacy> GetAll()
        {
            var result = new List<Pharmacy>();

            using var connection = new SqlConnection( _connectionString );
            connection.Open();

            using SqlCommand sqlCommand = connection.CreateCommand();
            sqlCommand.CommandText = "select [Id], [IdBrand], [Address], [PhoneNumber] from [Pharmacy]";

            using SqlDataReader reader = sqlCommand.ExecuteReader();
            while ( reader.Read() )
            {
                result.Add( new Pharmacy(
                    Convert.ToInt32( reader[ "Id" ] ),
                    Convert.ToInt32( reader[ "IdBrand"] ),
                    Convert.ToString( reader[ "Address" ] ),
                    Convert.ToString( reader[ "PhoneNumber" ] )
                    ) );
            }

            return result;
        }

        public Pharmacy GetById( int id )
        {
            using var connection = new SqlConnection( _connectionString );
            connection.Open();

            using SqlCommand sqlCommand = connection.CreateCommand();
            sqlCommand.CommandText = "select [Id], [IdBrand], [Address], [PhoneNumber] from [Pharmacy] where [Id] = @id";
            sqlCommand.Parameters.Add( "@id", SqlDbType.Int ).Value = id;

            using SqlDataReader reader = sqlCommand.ExecuteReader();
            if ( reader.Read() )
            {
                return new Pharmacy(
                    Convert.ToInt32( reader[ "Id" ] ),
                    Convert.ToInt32( reader[ "IdBrand" ] ),
                    Convert.ToString( reader[ "Address" ] ),
                    Convert.ToString( reader[ "PhoneNumber" ] )
                    );
            }
            else
            {
                return null;
            }
        }

        public void Update(Pharmacy pharmacy)
        {
            if (pharmacy == null )
            {
                throw new ArgumentNullException( nameof( pharmacy ) );
            }

            using var connection = new SqlConnection( _connectionString );
            connection.Open();

            using SqlCommand sqlCommand = connection.CreateCommand();
            sqlCommand.CommandText = "update [Pharmacy] set [Address] = @address, [PhoneNumber] = @phoneNumber where [Id] = @id";
            sqlCommand.Parameters.Add( "@id", SqlDbType.Int ).Value = pharmacy.Id;
            sqlCommand.Parameters.Add( "@address", SqlDbType.VarChar, 50 ).Value = pharmacy.Address;
            sqlCommand.Parameters.Add( "@phoneNumber", SqlDbType.VarChar, 25 ).Value = pharmacy.PhoneNumber;
            sqlCommand.ExecuteNonQuery();
        }
    }
}