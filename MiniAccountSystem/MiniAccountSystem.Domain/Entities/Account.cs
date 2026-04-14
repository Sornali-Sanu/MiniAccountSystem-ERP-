using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniAccountSystem.Domain.Entities
{
    public class Account
    {
        public int Id { get; set; }
        public string AccountCode { get; set; }
        public string AccountName { get; set; }
        public int AccountTypeId { get; set; }
        public AccountType AccountType { get; set; }
        public int? ParentAccountId { get; set; }
        public Account ParentAccount { get; set; }
        public ICollection<Account> ChildAccount { get; set; }
        public bool IsActive { get; set; }

    }
}
