using MediatR;
using Microsoft.AspNetCore.Mvc;
using POS.Application.Commands;
using POS.Application.Queries;
using POS.Domain.Entities;

namespace POS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAccount(CreateAccount.Request command)
        {
            var accountId = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetAccountByUsername), new { username = command.Username }, accountId);
        }

        [HttpGet("{username}")]
        public async Task<ActionResult<Account>> GetAccountByUsername(string username)
        {
            var account = await _mediator.Send(new GetAccountByUsername.Request() { Username = username});
            if (account == null) return NotFound();
            return Ok(account);
        }
    }
}
