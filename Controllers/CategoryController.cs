using Microsoft.AspNetCore.Mvc;
using WebApiAssigment2.DTOs;
using WebApiAssigment2.DTOs.Category;
using WebApiAssigment2.Models;
using WebApiAssigment2.Services.Interfaces;

namespace WebApiAssigment2.Controllers
{
    [Route("Category")]
    public class CategoryController : Controller
    {
        private readonly ILogger<CategoryController> _logger;
        private readonly ICategoryService _categoryService;

        public CategoryController(ILogger<CategoryController> logger, ICategoryService categoryService)
        {
            _logger = logger;
            _categoryService = categoryService;
        }
        [HttpGet]
        public IEnumerable<Category>? GetAll()
        {
            return _categoryService.GetAll();
        }
        [HttpPost]
        public AddCategoryResponse? Add([FromBody] AddCategoryRequest addCategoryRequest)
        {
            return _categoryService.Add(addCategoryRequest);
        }
        [HttpDelete]
        public CategoryViewModel? Delete([FromBody] DeleteCategoryRequest deleteCategoryRequest)
        {
            return _categoryService.Delete(deleteCategoryRequest);
        }
        [HttpPut]
        public CategoryViewModel? Update([FromBody] UpdateCategoryRequest updateCategoryRequest)
        {
            return _categoryService.Update(updateCategoryRequest);
        }
    }
}