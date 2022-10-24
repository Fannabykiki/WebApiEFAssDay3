using WebApiAssigment2.Models;

namespace WebApiAssigment2.Repositories.Interfaces
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(ProductStoreContext context) : base(context)
        {
        }
    }
}