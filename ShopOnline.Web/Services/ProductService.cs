using ShopOnline.Model.Dtos;
using ShopOnline.Web.Services.Contracts;
using System.Net.Http.Json;

namespace ShopOnline.Web.Services
{
    public class ProductService : IProductService
    {
        private readonly HttpClient httpClient;

        public ProductService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<ProductDto>> GetProducts()
        {
            try
            {
                var products = await httpClient.GetFromJsonAsync<IEnumerable<ProductDto>>("api/Product/products");
                return products;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
