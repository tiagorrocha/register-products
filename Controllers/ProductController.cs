using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using RegisterProducts.Models;
using RegisterProducts.Services;
using System.Threading.Tasks;
using System.Net.Http;

namespace RegisterProducts.Controllers
{
    [ApiController]
    [Route("v1/products")]
    public class ProductController : ControllerBase
    {
        [HttpPost]
        [Route("")]
        public async Task<ActionResult<HttpResponseMessage>> Create(
            [FromServices]ProductService productService,
            [FromBody]ProductDto product)
        {
            if (ModelState.IsValid)
            {
                var productId = await productService.Create(product);
                return Ok (new {
                    Id = productId
                });
            }
            else 
            {
                return BadRequest(ModelState);
            }
        }
        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<ProductDto>> GetById(int id,
        [FromServices]ProductService productService)
        {
            var productDto = await productService.GetById(id);
            if(productDto != null)
            {
                return productDto;
            }
            return NotFound(new {
                Error = "404 Not Found",
                Message = "The object with this id does not exist"
            });
        }
    }
}