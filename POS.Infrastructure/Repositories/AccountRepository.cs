using Microsoft.EntityFrameworkCore;
using POS.Application.Repositories;
using POS.Domain.Entities;
using POS.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace POS.Infrastructure.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly PosDBContext _context;

        public AccountRepository(PosDBContext context)
        {
            _context = context;
        }
        public async Task<Account> GetAccountByUsername(string username)
        {
            return await _context.Accounts.FirstOrDefaultAsync(x => x.Username == username);

        }

        public async Task AddAccount(Account account)
        {
            await _context.Accounts.AddAsync(account);
            await _context.SaveChangesAsync();
        }

    }
}
