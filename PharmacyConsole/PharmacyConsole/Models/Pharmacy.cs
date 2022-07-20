namespace BlogsApp.Models
{
    public class Pharmacy
    {
        public int Id { get; private set; }
        public int IdBrand { get; private set; }
        public string Address { get; private set; }
        public string PhoneNumber { get; private set; }
        public Pharmacy(int id, int idBrand, string address, string phoneNumber)
        {
            Id = id;
            IdBrand = idBrand;
            Address = address;
            PhoneNumber = phoneNumber;
        }

        public void UpdateAddress (string newAddress)
        {
            Address = newAddress;
        }

        public void UpdatePhoneNumber (string newPhoneNumber)
        {
            PhoneNumber = newPhoneNumber;
        }
    }
}
