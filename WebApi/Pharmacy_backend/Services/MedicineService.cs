using Pharmacy_backend.Domain;
using Pharmacy_backend.Repositories;

namespace Pharmacy_backend.Services
{
    public class MedicineService : IMedicineService
    {
        private readonly IMedicineRepository _medicineRepository;

        public MedicineService(IMedicineRepository medicineRepository)
        {
            _medicineRepository = medicineRepository;
        }

        public List<Medicine> GetAll()
        {
            return _medicineRepository.GetAll();
        }

        public void Delete(int Id)
        {
            Medicine medicine = _medicineRepository.Get(Id);
            if (medicine == null)
            {
                throw new Exception($"{nameof(Medicine)} not found, Id - {Id}");
            }

            _medicineRepository.Delete(medicine);
        }

        public List<QuantityMedicineInPharmacy> GetQuantityMedicineInPharmacyByName(string name)
        {
            List<QuantityMedicineInPharmacy> quantityMedicineInPharmacy = _medicineRepository.GetQuantityMedicineInPharmacyByName(name);
            if (quantityMedicineInPharmacy == null)
            {
                throw new Exception($"{nameof(QuantityMedicineInPharmacy)} not found, Name - {name}");
            }

            return quantityMedicineInPharmacy;
        }
    }
}
