using MediatR;
using POS.Domain.Entities;

namespace POS.Application.Queries
{
    public class GetAccountByUsername
    {
        public class Request : IRequest<Response>
        {
            public string Username { get; set; } = string.Empty;

        }

        public class Response
        {
            public int Id { get; set; }
            public string Username { get; set; } = string.Empty;
            public string Role { get; set; } = string.Empty;
        }
    }

    
}
