using Pharmacy_backend.Domain;

namespace Pharmacy_backend.Repositories
{
    public interface IPharmacyRepository
    {
        List<Pharmacy> GetAll();
        int Create(Pharmacy pharmacy);
        Pharmacy Get(int id);
        int Update(Pharmacy pharmacy);
        bool CheckId(int id);
    }
}
