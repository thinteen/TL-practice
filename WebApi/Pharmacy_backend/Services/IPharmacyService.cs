using Pharmacy_backend.Domain;
using Pharmacy_backend.Dto;

namespace Pharmacy_backend.Services
{
    public interface IPharmacyService
    {
        List<Pharmacy> GetAll();
        int Create(PharmacyDto pharmacy);
        int Update(PharmacyDto pharmacy);
    }
}
