using ShopOnline.Api.Models;
using ShopOnline.Model.Dtos;

namespace ShopOnline.Api.Extensions
{
    public static class DtoConversions
    {
        public static IEnumerable<ProductDto> ConvertToDto(this IEnumerable<Product> products, IEnumerable<ProductCategory> productCategories)
        {
            var productsDto = new List<ProductDto>();
            foreach (var product in products)
            {
                var category = productCategories.FirstOrDefault(x => x.Id == product.CategoryId);
                productsDto.Add(new ProductDto
                {
                    Id = product.Id,
                    Name = product.Name,
                    Description = product.Description,
                    ImageURL = product.ImageURL,
                    Price = product.Price,
                    Qty = product.Qty,
                    CategoryId = product.CategoryId,
                    CategoryName = category.Name
                });
            }


            return productsDto.ToList();
        }
    }
}
