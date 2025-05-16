using MediatR;
using POS.Application.Commands;
using POS.Application.Repositories;
using POS.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace POS.Infrastructure.Handlers
{
    public class CreateAccountHandler : IRequestHandler<CreateAccount.Request, CreateAccount.Response>
    {
        private readonly IAccountRepository _repository;

        public CreateAccountHandler(IAccountRepository repository)
        {
            _repository = repository;
        }

        public async Task<CreateAccount.Response> Handle(CreateAccount.Request request, CancellationToken cancellationToken)
        {
            var account = new Account
            {
                Username = request.Username,
                Password = request.Password,
                Role = request.Role
            };

            await _repository.AddAccount(account);

            return new CreateAccount.Response
            {
                Id = account.Id
            };
        }
    }
}
