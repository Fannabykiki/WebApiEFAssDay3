using WebApiAssigment2.DTOs;
using WebApiAssigment2.DTOs.Category;
using WebApiAssigment2.Models;
using WebApiAssigment2.Repositories.Interfaces;
using WebApiAssigment2.Services.Interfaces;

namespace WebApiAssigment2.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public AddCategoryResponse? Add(AddCategoryRequest addCategoryRequest)
        {
            using (var transaction = _categoryRepository.DatabaseTransaction())
                try
                {
                    var addCategory = new Category
                    {
                        CategoryName = addCategoryRequest.CategoryName
                    };
                    var category = _categoryRepository.Create(addCategory);

                    _categoryRepository.SaveChanges();

                    transaction.Commit();

                    return new AddCategoryResponse
                    {
                        CategoryName = category.CategoryName,
                        CategoryId = category.Id
                    };                  
                }
                catch (Exception)
                {
                    transaction.RollBack();

                    return null;
                }
        }

        public CategoryViewModel? Delete(DeleteCategoryRequest deleteCategoryRequest)
        {
            using (var transaction = _categoryRepository.DatabaseTransaction())
                try
                {
                    var category = _categoryRepository.Get(s => s.Id == deleteCategoryRequest.CategoryId);
                    if (category != null)
                    {
                        _categoryRepository.Delete(category);
                        _categoryRepository.SaveChanges();
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

        public IEnumerable<Category>? GetAll()
        {
            return _categoryRepository.GetAll(x => true);
        }

        public CategoryViewModel? Update(UpdateCategoryRequest updateCategoryRequest)
        {
            using (var transaction = _categoryRepository.DatabaseTransaction())
                try
                {
                    var category = _categoryRepository.Get(s => s.Id == updateCategoryRequest.CategoryId);
                    if (category != null)
                    {
                        category.Id = updateCategoryRequest.CategoryId;
                        category.CategoryName = updateCategoryRequest.CategoryName;
                        _categoryRepository.SaveChanges();
                    }
                    _categoryRepository.Update(category);

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