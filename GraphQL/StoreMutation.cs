using LessonThree.Abstractions;
using LessonThree.Contracts.Requests.Store;

namespace LessonThree.GraphQL
{
    public class StoreMutation
    {
        private readonly IStoreService _storeService;
        public StoreMutation(IStoreService storeService)
        {
            _storeService = storeService;
        }

        public int AddProduct(AddInfoProductInStore input) => _storeService.AddProduct(input);
        public int GetProduct(GetInfoProductInStore input) => _storeService.GetProduct(input);
    }
}
