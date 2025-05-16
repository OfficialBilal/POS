using MediatR;
using POS.Application.Queries;
using POS.Application.Repositories;
using POS.Domain.Entities;
using ProductEntity = POS.Domain.Entities.Product;

namespace POS.Infrastructure.Handlers
{
    public class GetProductByIdHandler : IRequestHandler<GetProductById.Request, GetProductById.Response>
    {
        private readonly IProductRepository _repository;

        public GetProductByIdHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetProductById.Response> Handle(GetProductById.Request request, CancellationToken cancellationToken)
        {
            var product = await _repository.GetProductById(request.Id);
            return new()
            {
                Name = product?.Name ?? string.Empty,
                Price = product?.Price ?? 0,
                Quantity = product?.Quantity ?? 0
            };
        }
    }
}
