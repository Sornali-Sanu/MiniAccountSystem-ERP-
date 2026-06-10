using MiniAccountSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniAccountSystem.Application.Interfaces
{
    public interface IAccountTypeRepository
    {
        Task<IEnumerable<AccountType>> GetAllAccountTypeAsync();
        Task<AccountType?> GetByIdAsync(int id);
    }
}
