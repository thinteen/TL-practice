using BlogsApp.Models;

namespace BlogsApp.Repositories
{
    public interface IPharmacyRepository
    {
        IReadOnlyList<Pharmacy> GetAll();
        Pharmacy GetById( int id );
        void Update(Pharmacy pharmacy);
    }
}