using MediatR;
using POS.Application.Queries;
using POS.Application.Repositories;
using POS.Domain.Entities;

namespace POS.Infrastructure.Handlers
{
    public class GetAccountByUsernameHandler : IRequestHandler<GetAccountByUsername.Request, GetAccountByUsername.Response>
    {
        private readonly IAccountRepository _repository;

        public GetAccountByUsernameHandler(IAccountRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetAccountByUsername.Response?> Handle(GetAccountByUsername.Request request, CancellationToken cancellationToken)
        {
            var u = await _repository.GetAccountByUsername(request.Username);
            
            return new()
            {
               Role = u?.Role.ToString() ?? string.Empty,
               Id = u?.Id ?? 0,
               Username = u?.Username ?? string.Empty
            };
        }
    }
}
