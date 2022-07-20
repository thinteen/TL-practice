using BlogsApp.Models;

namespace BlogsApp.Repositories
{
    public interface IMedicineRepository
    {
        IReadOnlyList<Medicine> GetAll();
        Medicine GetByName(string name);
        IReadOnlyList<QuantityMedicineInPharmacy> GetQuantityMedicineInPharmacyByName(string name);
        IReadOnlyList<NumberOfVarietiesOfMedicines> GetNumberOfVarietiesOfMedicines();
    }
}