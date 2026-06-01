using MiniAccountSystem.Application.Interfaces;
using MiniAccountSystem.Domain.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniAccountSystem.Application.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _repo;

        public AccountService(IAccountRepository repo)
        {
            _repo = repo;
        }

        public async Task CreateAccountAsync(Account account)
        {
            if (string.IsNullOrEmpty(account.AccountName))
                throw new Exception("Account Name is required");
            await _repo.AddAccount(account);
        }

        public async Task DeleteAccountAsync(int id)
        {
            if (id == null)
                throw new Exception("Account not Found");
            await _repo.DeleteAccount(id);
        }

        public async Task<Account> GetAccountByIdAsync(int id)
        {
            return await _repo.GetAccountById(id);
        }

        public Task<IEnumerable<AccountType>> GetAccountTypesAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Account>> GetAllAccountsAsync()
        {
            return await _repo.GetAllAccount();
        }

        public async Task<IEnumerable<Account>> GetParentAccountsAsync()
        {
            return await _repo.GetAllAccount();
        }

        public async Task UpdateAccountAsync(Account account)
        {
           await _repo.UpdateAccount(account);
        }
    }
}
