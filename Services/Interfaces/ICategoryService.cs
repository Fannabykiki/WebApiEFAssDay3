using WebApiAssigment2.DTOs;
using WebApiAssigment2.DTOs.Category;
using WebApiAssigment2.Models;
namespace WebApiAssigment2.Services.Interfaces
{
    public interface ICategoryService
    {
         IEnumerable<Category>? GetAll();
        AddCategoryResponse? Add(AddCategoryRequest addCategoryRequest);
        CategoryViewModel? Update(UpdateCategoryRequest updateCategoryRequest);
        CategoryViewModel? Delete(DeleteCategoryRequest deleteCategoryRequest);
    }
}