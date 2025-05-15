using Microsoft.AspNetCore.Mvc;
using MediatR;
using POS.Domain.Entities;
using POS.Application.Commands;
using POS.Application.Queries;

namespace POS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProduct.Request command)
        {
            var productId = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetProductById), new { id = productId }, productId);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProductById(int id)
        {
            var product = await _mediator.Send(new GetProductById.Request() { Id = id});
            if (product == null)
                return NotFound();

            return Ok(product);
        }
    }
}
