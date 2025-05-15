using MediatR;

namespace POS.Application.Commands;

public class CreateAccount
{
    public class Request : IRequest<Response>
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Role { get; set; } = "User";
    }

    public class Response
    {
        public int Id { get; set; }
    }
}


