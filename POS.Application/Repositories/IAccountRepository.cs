using POS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Application.Repositories
{
    public interface IAccountRepository
    {
        Task<Account> GetAccountByUsername(string username);
        Task AddAccount(Account account);
    }
}
