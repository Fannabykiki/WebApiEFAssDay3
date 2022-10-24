using WebApiAssigment2.DTOs;
using WebApiAssigment2.Models;
using WebApiAssigment2.Repositories.Interfaces;
using WebApiAssigment2.Services.Interfaces;

namespace WebApiAssigment2.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        public ProductService(IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }
        public AddProductResponse? Add(AddProductRequest addProductRequest)
        {
            using (var transaction = _productRepository.DatabaseTransaction())
                try
                {
                    var category = _categoryRepository.Get(s => s.Id == addProductRequest.CategoryId);
                    if (category != null)
                    {
                        var addProduct = new Product
                        {
                            ProductName = addProductRequest.ProductName,
                            CategoryId = category.Id,
                            Manufacture = addProductRequest.Manufacture
                        };

                        var newProduct = _productRepository.Create(addProduct);
                        _productRepository.SaveChanges();

                        transaction.Commit();

                        return new AddProductResponse
                        {
                            ProductId = newProduct.Id,
                            ProductName = newProduct.ProductName,
                            CategoryId = newProduct.CategoryId
                        };
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (Exception)
                {
                    transaction.RollBack();

                    return null;
                }
        }

        public ProductViewModel? Delete(DeleteProductRequest deleteProductRequest)
        {
            using (var transaction = _productRepository.DatabaseTransaction())
                try
                {
                    var product = _productRepository.Get(s => s.Id == deleteProductRequest.ProductId);
                    if (product != null)
                    {
                        _productRepository.Delete(product);
                        _productRepository.SaveChanges();
                    }
                    transaction.Commit();

                    return null;
                }
                catch (Exception)
                {
                    transaction.RollBack();

                    return null;
                }
        }

        public IEnumerable<Product> GetAll()
        {
            return _productRepository.GetAll(x => true);
        }

        public ProductViewModel? Update(UpdateProductRequest updateProductRequest)
        {
            using (var transaction = _productRepository.DatabaseTransaction())
                try
                {
                    var product = _productRepository.Get(s => s.Id == updateProductRequest.ProductId);
                    if (product != null)
                    {
                        product.ProductName = updateProductRequest.ProductName;
                        product.Manufacture = updateProductRequest.Manufacture;
                        _productRepository.SaveChanges();
                    }
                    _productRepository.Update(product);
                    transaction.Commit();

                    return null;
                }
                catch (Exception)
                {
                    transaction.RollBack();

                    return null;
                }
        }
    }
}