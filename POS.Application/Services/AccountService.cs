using POS.Application.Repositories;
using POS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Application.Services
{
    public class AccountService
    {
        private readonly IAccountRepository _accountRepository;

        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async Task<Account> GetAccountByUsername(string username)
        {
            return await _accountRepository.GetAccountByUsername(username);
        }

        public async Task AddAccount(Account account)
        {
            await _accountRepository.AddAccount(account);
        }

    }
}
