using AutoMapper;
using LessonThree.Contracts.Requests.Store;
using LessonThree.Contracts.Responses;
using Microsoft.Extensions.Caching.Memory;
using StoreMarket.Context;
using StoreMarket.Models;

namespace LessonThree.Services
{
    public class StoreService
    {
        private readonly StoreContext _storeContext;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _memoryCash;

        public StoreService(StoreContext context, IMapper mapper, IMemoryCache memoryCash)
        {
            _mapper = mapper;
            _storeContext = context;
        }

        public int AddProduct(AddInfoProductInStore product)
        {
            var mapEntity = _mapper.Map<Product>(product);
            _storeContext.Products.Add(mapEntity);
            _storeContext.SaveChanges();
            _memoryCash.Remove("products");
            return mapEntity.Id;
        }

        public StoreResponse GetProduct(int id)
        {
            var product = _storeContext.Products.FirstOrDefault(x => x.Id == id);
            if (product == null)
            {
                return null;
            }
            return _mapper.Map<StoreResponse>(product);
        }
    }
}
