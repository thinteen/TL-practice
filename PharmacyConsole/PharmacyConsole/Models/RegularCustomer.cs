namespace BlogsApp.Models
{
    public class RegularCustomer
    {
        public int Id { get; private set; }
        public int IdBrand { get; private set; }
        public string FullName { get; private set; }
        public string PhoneNumber { get; private set; }
        public string CustomerCardNumber { get; private set; }
        public int AccumulatedPoints { get; private set; }
        public RegularCustomer(int id, int idBrand, string fullName, string phoneNumber, string customerCardNumber, int accumulatedPoints)
        {
            Id = id;
            IdBrand = idBrand;
            FullName = fullName;
            PhoneNumber = phoneNumber;
            CustomerCardNumber = customerCardNumber;
            AccumulatedPoints = accumulatedPoints;
        }
    }
}