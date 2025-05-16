using MediatR;
using POS.Domain.Entities;
using POS.Application.Commands;
using POS.Application.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace POS.Infrastructure.Handlers
{
    public class CreateProductHandler : IRequestHandler<CreateProduct.Request, CreateProduct.Response>
    {
        private readonly IProductRepository _repository;

        public CreateProductHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<CreateProduct.Response> Handle(CreateProduct.Request request, CancellationToken cancellationToken)
        {
            var product = new Product
            {
                Name = request.Name,
                Price = request.Price,
                Quantity = request.Quantity
            };

            await _repository.AddProduct(product);

            return new CreateProduct.Response
            {
                Id = product.Id
            };
        }
    }
}
