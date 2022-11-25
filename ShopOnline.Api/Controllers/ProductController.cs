using Microsoft.AspNetCore.Mvc;
using ShopOnline.Api.Extensions;
using ShopOnline.Api.UnitOfWorks;

namespace ShopOnline.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        public ProductController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet("products")]
        public async Task<IActionResult> GetProducts()
        {
            try
            {
                var products = await unitOfWork.ProductRepository.GetProductsAsync();
                var productCategory = await unitOfWork.ProductRepository.GetCategoriesAsync();

                if(products == null || productCategory == null) return NotFound();

                var productDtos = products.ConvertToDto(productCategory);
                return Ok(productDtos);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to retrieve data from database");
            }
            
        }

        [HttpGet("products/{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var products = await unitOfWork.ProductRepository.GetProductById(id);
            if (products == null) return NotFound();

            return Ok(products);
        }
    }
}
