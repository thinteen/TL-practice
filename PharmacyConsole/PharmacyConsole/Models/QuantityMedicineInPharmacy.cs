namespace BlogsApp.Models
{
    public class QuantityMedicineInPharmacy
    {
        public string BrandName { get; private set; }
        public string Address { get; private set; }
        public string MedicineName { get; private set; }
        public int Quantity { get; private set; }
        public int Price { get; private set; }
        public QuantityMedicineInPharmacy(string brandName, string address, string medicineName, int quantity, int price)
        {
            BrandName = brandName;
            Address = address;
            MedicineName = medicineName;
            Quantity = quantity;
            Price = price;
        }
    }
}
