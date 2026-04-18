using MiniAccountSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniAccountSystem.Infrastructure.Interfaces
{
    public interface IAccountRepository
    {
        Task<IEnumerable<Account>> GetAllAccount();
        Task<Account> GetAccountById(int Id);
        Task AddAccount(Account account);
        Task UpdateAccount(Account account);
        Task DeleteAccount(int Id);
    }
}
