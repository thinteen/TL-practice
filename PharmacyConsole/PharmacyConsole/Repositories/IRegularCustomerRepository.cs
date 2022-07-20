using BlogsApp.Models;

namespace BlogsApp.Repositories
{
    public interface IRegularCustomerRepository
    {
        IReadOnlyList<RegularCustomer> GetAll();
        RegularCustomer GetById(int id);
        void Delete(RegularCustomer regularCustomer);
    }
}