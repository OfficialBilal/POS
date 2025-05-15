using MediatR;
using POS.Domain.Entities;
using POS.Infrastructure.Data;
using POS.Application.Commands;

namespace POS.Infrastructure.Handlers
{
    public class CreateProductHandler : IRequestHandler<CreateProduct.Request, CreateProduct.Response>
    {
        private readonly PosDBContext _context;

        public CreateProductHandler(PosDBContext context)
        {
            _context = context;
        }

        public async Task<CreateProduct.Response> Handle(CreateProduct.Request request, CancellationToken cancellationToken)
        {
            var product = new Product
            {
                Name = request.Name,
                Price = request.Price,
                Quantity = request.Quantity
            };

            _context.Products.Add(product);
            await _context.SaveChangesAsync(cancellationToken);

            return new()
            {
                Id = product.Id,
            };
        }
    }
}
