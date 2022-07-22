using Pharmacy_backend.Domain;

namespace Pharmacy_backend.Repositories
{
    public interface IMedicineRepository
    {
        List<Medicine> GetAll();
        Medicine Get(int id);
        void Delete(Medicine medicine);
        List<QuantityMedicineInPharmacy> GetQuantityMedicineInPharmacyByName(string name);
    }
}
