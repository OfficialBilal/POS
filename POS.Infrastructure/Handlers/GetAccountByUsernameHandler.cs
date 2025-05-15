using MediatR;
using Microsoft.EntityFrameworkCore;
using POS.Application.Queries;
using POS.Domain.Entities;
using POS.Infrastructure.Data;

namespace POS.Infrastructure.Handlers
{
    public class GetAccountByUsernameHandler : IRequestHandler<GetAccountByUsername.Request, GetAccountByUsername.Response>
    {
        private readonly PosDBContext _context;

        public GetAccountByUsernameHandler(PosDBContext context)
        {
            _context = context;
        }

        public async Task<GetAccountByUsername.Response?> Handle(GetAccountByUsername.Request request, CancellationToken cancellationToken)
        {
            var u = await _context.Accounts
                .FirstOrDefaultAsync(a => a.Username == request.Username, cancellationToken);
            
            return new()
            {
               Role = u?.Role.ToString() ?? string.Empty,
               Id = u?.Id ?? 0,
               Username = u?.Username ?? string.Empty
            };
        }
    }
}
