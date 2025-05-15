using MediatR;
using POS.Application.Commands;
using POS.Domain.Entities;
using POS.Infrastructure.Data;

namespace POS.Infrastructure.Handlers
{
    public class CreateAccountHandler : IRequestHandler<CreateAccount.Request, CreateAccount.Response>
    {
        private readonly PosDBContext _context;

        public CreateAccountHandler(PosDBContext context)
        {
            _context = context;
        }

        public async Task<CreateAccount.Response> Handle(CreateAccount.Request request, CancellationToken cancellationToken)
        {
            var account = new Account
            {
                Username = request.Username,
                Password = request.Password,
                Role = request.Role
            };

            _context.Accounts.Add(account);
            await _context.SaveChangesAsync(cancellationToken);

            return  new()
            {
                Id = account.Id
            };
        }
    }
}
