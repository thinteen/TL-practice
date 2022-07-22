using Pharmacy_backend.Domain;

namespace Pharmacy_backend.Services
{
    public interface IMedicineService
    {
        List<Medicine> GetAll();
        void Delete(int Id);
        List<QuantityMedicineInPharmacy> GetQuantityMedicineInPharmacyByName(string name);
    }
}
