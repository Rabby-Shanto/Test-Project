using GNIT.Application.Handlers.Contracts;
using GNIT.Domain.Product;
using GNIT.Domain.Query;
using GNIT.Presentation.Controllers.Base;
using Microsoft.AspNetCore.Mvc;

namespace GNIT.Presentation.Controllers
{
    public class ProductController(IProductHandler productHandler) : BaseApiController
    {
        private readonly IProductHandler _productHandler = productHandler;

        [HttpGet]
        public async Task<IActionResult> GetProducts([FromQuery] Query query)
        {
            var products = await _productHandler.GetProducts(query);
            return Ok(products);
        }


        [HttpGet("GetIndividualProduct")]
        public async Task<IActionResult> GetProduct([FromQuery] Query query)
        {
            var product = await _productHandler.GetProduct(query);
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(Product product)
        {
            var response = await _productHandler.CreateProduct(product);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct(Product product)
        {
            var response = await _productHandler.UpdateProduct(product);
            return Ok(response);
        }


        [HttpDelete("DeleteProduct")]
        public async Task<IActionResult> DeleteProduct([FromQuery] Query query)
        {
            var response = await _productHandler.DeleteProduct(query);
            return Ok(response);
        }
        
    }
}
