using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using POS.Application.Repositories;
using POS.Application.Services;
using POS.Domain.Entities;

namespace POS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _productService;

        public ProductController(ProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        public async Task AddProduct(Product product)
        {
            await _productService.AddProduct(product);
            Ok(product);
        }

        [HttpDelete]
        public async Task DeleteProduct(int id)
        {
            await _productService.DeleteProduct(id);
            NoContent();
           
        }

        [HttpGet]
        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            var product = await _productService.GetAllProducts();
            return product;
        }

        [HttpGet("{id}")]
        public async Task<Product> GetProductById(int id)
        {
            var product =  await _productService.GetProductById(id);
            if (product == null)
            {
                NotFound();
            }

            return product;

        }

        [HttpPut("{id}")]
        public async Task UpdateProduct(Product product, int id)
        {
            if (id != product.Id)
                BadRequest();

            await _productService.UpdateProduct(product, id);
            NoContent();

        }
    }
}
