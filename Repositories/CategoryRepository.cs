using WebApiAssigment2.Models;
using WebApiAssigment2.Repositories.Interfaces;

namespace WebApiAssigment2.Repositories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(ProductStoreContext context) : base(context)
        {
        }
    }
}