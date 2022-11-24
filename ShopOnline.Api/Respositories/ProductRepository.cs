using Microsoft.EntityFrameworkCore;
using ShopOnline.Api.Contracts;
using ShopOnline.Api.Data;
using ShopOnline.Api.Models;

namespace ShopOnline.Api.Respositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ShopOnlineDbContext context;

        public ProductRepository(ShopOnlineDbContext context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<ProductCategory>> GetCategoriesAsync()
        {
            var products = await context.ProductCategories.ToListAsync();

            return products;
        }

        public async Task<ProductCategory> GetCategoryById(int id)
        {
            var category = await context.ProductCategories.FirstOrDefaultAsync(x => x.Id == id);
            if (category == null) return null;

            return category;
        }

        public async Task<Product> GetProductById(int id)
        {
            var product = await context.Products.FirstOrDefaultAsync(x => x.Id == id);
            if (product == null) return null;

            return product;
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            var products = await context.Products.ToListAsync();

            return products;
        }
    }
}
