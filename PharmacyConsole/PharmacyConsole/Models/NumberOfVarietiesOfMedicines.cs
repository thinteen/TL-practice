namespace BlogsApp.Models
{
    public class NumberOfVarietiesOfMedicines
    {
        public int IdPharmacy { get; private set; }
        public int IdMedicine { get; private set; }
        public NumberOfVarietiesOfMedicines(int idPharmacy, int idMedicine)
        {
            IdPharmacy = idPharmacy;
            IdMedicine = idMedicine;
        }
    }
}