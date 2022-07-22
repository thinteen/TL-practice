using Pharmacy_backend.Domain;
using Pharmacy_backend.Dto;
using Pharmacy_backend.Repositories;

namespace Pharmacy_backend.Services
{
    public class PharmacyService : IPharmacyService
    {
        private readonly IPharmacyRepository _pharmacyRepository;

        public PharmacyService(IPharmacyRepository pharmacyRepository)
        {
            _pharmacyRepository = pharmacyRepository;
        }

        public List<Pharmacy> GetAll()
        {
            return _pharmacyRepository.GetAll();
        }

        public int Create(PharmacyDto pharmacyDto)
        {
            if (pharmacyDto == null)
            {
                throw new Exception($"{nameof(Pharmacy)} not found");
            }

            Pharmacy pharmacyEntity = pharmacyDto.ConvertToPharmacy();

            return _pharmacyRepository.Create(pharmacyEntity);
        }

        public int Update(PharmacyDto pharmacyDto)
        {
            if (pharmacyDto == null)
            {
                throw new Exception($"{nameof(pharmacyDto)} not found");
            }
            
            if (_pharmacyRepository.CheckId(pharmacyDto.Id))
            {
                return _pharmacyRepository.Update(pharmacyDto.ConvertToPharmacy());
            }
            else
            {
                throw new Exception($"{nameof(pharmacyDto)} not found with id {pharmacyDto.Id}");
            }
        }
    }
}
