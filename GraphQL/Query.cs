using LessonThree.Abstractions;
using LessonThree.Contracts.Responses;
using StoreMarket.Abstractions;
using StoreMarket.Contracts.Responses;
using StoreMarket.Models;

namespace LessonThree.GraphQL
{
    public class Query
    {
        private readonly IProductService _productService;        
        private readonly ICategoryService _categoryService;
        public Query(IProductService productSrevice, ICategoryService categoryService)
        {
            _productService = productSrevice;
            _categoryService = categoryService;
        }
        public IEnumerable<CategoryResponse> GetCategories() => _categoryService.GetCategories();
        public IEnumerable<ProductResponse> GetProducts() => _productService.GetProducts();
        public ProductResponse GetProductById(int id) => _productService.GetProductById(id);     



    }
}
