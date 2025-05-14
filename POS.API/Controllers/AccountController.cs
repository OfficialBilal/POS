using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using POS.Application.Repositories;
using POS.Application.Services;
using POS.Domain.Entities;

namespace POS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly AccountService _accountService;

        public AccountController(AccountService accountService)
        {
            _accountService = accountService;
        }


        [HttpPost("{register}")]
        public async Task<IActionResult> Register(Account account)
        {
            await _accountService.AddAccount(account);
            return Ok( new { meassage = "Account Created Successfully"} );
        }

        [HttpGet("{username}")]
        public async Task<ActionResult<Account>> GetAccountByUsername(string username)
        {
           var account = await _accountService.GetAccountByUsername(username);
            if(account == null)
            {
                NotFound();
            }
            return Ok(account);
        }


    }
}
