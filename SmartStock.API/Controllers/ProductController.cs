using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartStock.Domain.Entities;
using SmartStock.Domain.Interfaces.Services;

namespace SmartStock.API.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet, Authorize]
        public async Task<ActionResult<IEnumerable<Order>>> GetAllOrders()
        {
            try
            {
                var products = await _productService.GetAllProducts();
                return Ok(products);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{orderId}"), Authorize]
        public async Task<ActionResult<Order>> GetOrderById(int orderId)
        {
            try
            {
                var product = await _productService.GetProductById(orderId);
                if (product == null)
                {
                    return NotFound("Produto não encontrado!");
                }

                return Ok(product);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost, Authorize]
        public async Task<ActionResult<Product>> NewOrder(Product product)
        {
            try
            {
                var newProduct = await _productService.NewProduct(product);

                return Ok(newProduct);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut, Authorize]
        public async Task<ActionResult> UpdateUser(Product product)
        {
            try
            {
                var updateProduct = await _productService.UpdateProduct(product);

                return Ok(updateProduct);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}"), Authorize]
        public async Task<ActionResult> DeleteUser(int id)
        {
            try
            {
                var deleteProduct = await _productService.DeleteProductById(id);

                return Ok(deleteProduct);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
