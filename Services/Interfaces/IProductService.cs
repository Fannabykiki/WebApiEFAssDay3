using WebApiAssigment2.DTOs;
using WebApiAssigment2.Models;

namespace WebApiAssigment2.Services.Interfaces
{
    public interface IProductService
    {   
        IEnumerable<Product>? GetAll();
        AddProductResponse? Add(AddProductRequest addProductRequest);
        ProductViewModel? Update(UpdateProductRequest updateProductRequest);
        ProductViewModel? Delete(DeleteProductRequest deleteProductRequest);
    }
}