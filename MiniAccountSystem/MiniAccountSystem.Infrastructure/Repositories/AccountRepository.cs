using Azure.Messaging;
using Microsoft.EntityFrameworkCore;
using MiniAccountSystem.Domain.Entities;
using MiniAccountSystem.Infrastructure.Data;
using MiniAccountSystem.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniAccountSystem.Infrastructure.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly ApplicationDbContext _db;

        public AccountRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task AddAccount(Account account)
        {
          await _db.Accounts.AddAsync(account);
          await _db.SaveChangesAsync();
        }

        public async Task DeleteAccount(int Id)
        {
            var account=await _db.Accounts.FindAsync(Id);
            if (account != null)
            {
                _db.Accounts.Remove(account);
                await _db.SaveChangesAsync();
            }
           
        }

        public async Task<Account> GetAccountById(int Id)
        {
            return await _db.Accounts.Include(a => a.AccountType).FirstOrDefaultAsync(a => a.Id == Id);
        }

        public async Task<IEnumerable<Account>> GetAllAccount()
        {
            return await _db.Accounts.Include(a => a.AccountType).ToListAsync();
        }

        public Task UpdateAccount(Account account)
        {
            throw new NotImplementedException();
        }
    }
}
