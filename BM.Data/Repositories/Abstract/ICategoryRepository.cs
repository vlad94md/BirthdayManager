using BM.Data.Infrastructure;
using BM.Model;

namespace BM.Data.Repositories
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Category GetCategoryByName(string categoryName);
    }
}