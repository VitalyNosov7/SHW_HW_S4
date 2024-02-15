using AutoMapper;
using LessonThree.Contracts.Requests.Categories;
using LessonThree.Contracts.Requests.Products;
using LessonThree.Contracts.Responses;
using StoreMarket.Contracts.Responses;
using StoreMarket.Models;

namespace StoreMarket.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductResponse>(MemberList.Destination).ReverseMap();
            CreateMap<Product, ProductCreateRequest>(MemberList.Destination).ReverseMap();
            CreateMap<Product, ProductDeleteRequest>(MemberList.Destination).ReverseMap();
            CreateMap<Product, ProductUpdateRequest>(MemberList.Destination).ReverseMap();

            CreateMap<Category, CreateCategoryRequest>(MemberList.Destination).ReverseMap();
            CreateMap<Category, CategoryResponse>(MemberList.Destination).ReverseMap();
        }
    }
}
