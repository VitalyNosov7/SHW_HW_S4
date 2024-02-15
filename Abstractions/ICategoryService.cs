using LessonThree.Contracts.Requests.Categories;
using LessonThree.Contracts.Responses;

namespace LessonThree.Abstractions
{
    public interface ICategoryService
    {
        int AddCategory(CreateCategoryRequest createCategoryRequest);
        IEnumerable<CategoryResponse> GetCategories();
    }
}
