using MediatR;
using Microsoft.EntityFrameworkCore;
using POS.Application.Queries;
using POS.Domain.Entities;
using POS.Infrastructure.Data;
using ProductEntity = POS.Domain.Entities.Product;

namespace POS.Infrastructure.Handlers
{
    public class GetProductByIdHandler : IRequestHandler<GetProductById.Request, GetProductById.Response>
    {
        private readonly PosDBContext _context;

        public GetProductByIdHandler(PosDBContext context)
        {
            _context = context;
        }

        public async Task<GetProductById.Response> Handle(GetProductById.Request request, CancellationToken cancellationToken)
        {
            var product = await _context.Products
                .FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);
            return new()
            {
                Name = product?.Name ?? string.Empty,
                Price = product?.Price ?? 0,
                Quantity = product?.Quantity ?? 0
            };
        }
    }
}
