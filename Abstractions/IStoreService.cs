using LessonThree.Contracts.Requests.Store;

namespace LessonThree.Abstractions
{
    public interface IStoreService
    {
        public int AddProduct(AddInfoProductInStore product);
        public int GetProduct(GetInfoProductInStore product);
    }
}
