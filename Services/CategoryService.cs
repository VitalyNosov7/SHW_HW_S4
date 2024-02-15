using AutoMapper;
using LessonThree.Abstractions;
using LessonThree.Contracts.Requests.Categories;
using LessonThree.Contracts.Responses;
using StoreMarket.Context;
using StoreMarket.Contracts.Responses;
using StoreMarket.Models;

namespace LessonThree.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IMapper _mapper;
        private readonly StoreContext _storeContext;

        public CategoryService(StoreContext storeContext, IMapper mapper)
        {
            _storeContext = storeContext;
            _mapper = mapper;
        }
        public int AddCategory(CreateCategoryRequest createCategoryRequest)
        {
            var mapEntity = _mapper.Map<Category>(createCategoryRequest);
            _storeContext.Categories.Add(mapEntity);
            _storeContext.SaveChanges();
            
            return mapEntity.Id;
        }

        public IEnumerable<CategoryResponse> GetCategories()
        {
            IEnumerable<CategoryResponse> products = _storeContext.Categories.Select(_mapper.Map<CategoryResponse>);         

            return products;
        }
    }
}
