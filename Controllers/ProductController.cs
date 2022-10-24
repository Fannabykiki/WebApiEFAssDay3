using Microsoft.AspNetCore.Mvc;
using WebApiAssigment2.DTOs;
using WebApiAssigment2.Models;
using WebApiAssigment2.Services.Interfaces;

namespace WebApiAssigment2.Controllers
{
    [Route("Product")]
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IProductService _productService;

        public ProductController(ILogger<ProductController> logger, IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }
        [HttpGet]
        public IEnumerable<Product>? GetAll()
        {
            return _productService.GetAll();
        }
        [HttpPost]
        public AddProductResponse? Add([FromBody] AddProductRequest addProduct)
        {
            return _productService.Add(addProduct);
        }
        [HttpDelete]
        public ProductViewModel? Delete([FromBody] DeleteProductRequest deleteProductRequest)
        {
            return _productService.Delete(deleteProductRequest);
        }
        [HttpPut]
        public ProductViewModel? Update([FromBody] UpdateProductRequest updateProductRequest)
        {
            return _productService.Update(updateProductRequest);
        }
    }
}