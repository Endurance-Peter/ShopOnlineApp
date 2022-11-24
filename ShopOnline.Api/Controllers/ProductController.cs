using Microsoft.AspNetCore.Mvc;
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
            var products = await unitOfWork.ProductRepository.GetProductsAsync();
            return Ok(products);
        }

        [HttpGet("products/{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var products = await unitOfWork.ProductRepository.GetProductById(id);

            return Ok(products);
        }
    }
}
