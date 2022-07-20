using BlogsApp.Models;

namespace BlogsApp.Repositories
{
    public interface IBrandRepository
    {
        IReadOnlyList<Brand> GetAll();
    }
}