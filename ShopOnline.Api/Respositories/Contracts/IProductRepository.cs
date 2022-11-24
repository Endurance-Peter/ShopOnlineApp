using ShopOnline.Api.Models;

namespace ShopOnline.Api.Contracts
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProductsAsync();
        Task<IEnumerable<ProductCategory>> GetCategoriesAsync();
        Task<Product> GetProductById(int id);
        Task<ProductCategory> GetCategoryById(int id);
    }
}
