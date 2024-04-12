using ListaProdutos.API.ViewModel;
using ListaProdutos.Domain.DTO;
using ListaProdutos.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ListaProdutos.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]ProductViewModel product)
        {
            var productDTO = new ProductDTO
            {
                Name = product.Name,
                Price = product.Price,
                Stock = product.Stock,
                ExpirationDate = product.ExpirationDate,
                Category = product.Category
            };

            var result = await _productRepository.Create(productDTO);

            return Ok(result);
        }
    }
}
