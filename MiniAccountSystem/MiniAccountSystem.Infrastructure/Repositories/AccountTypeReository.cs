using Microsoft.EntityFrameworkCore;
using MiniAccountSystem.Application.Interfaces;
using MiniAccountSystem.Domain.Entities;
using MiniAccountSystem.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniAccountSystem.Infrastructure.Repositories
{
    public class AccountTypReository : IAccountTypeRepository
    {
        private readonly ApplicationDbContext _db;

        public AccountTypReository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<AccountType>> GetAllAccountTypeAsync()
        {
            return await _db.AccountTypes.OrderBy(x => x.Name).ToListAsync();
        }

        public async Task<AccountType?> GetByIdAsync(int id)
        {
            return await _db.AccountTypes
           .FirstOrDefaultAsync(x => x.Id == id);
        }



       
       
    }
}
