using Microsoft.EntityFrameworkCore;
using MiniAccountSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniAccountSystem.Infrastructure.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)
        {

            
        }
        public DbSet<AccountType> AccountTypes { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<JournalEntry> JournalEntries { get; set; }
        public DbSet<JournalDetail> JournalDetails { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //Self relationship (account):
            modelBuilder.Entity<Account>().HasOne(a => a.ParentAccount).WithMany(a => a.ChildAccount).HasForeignKey(a => a.ParentAccountId).OnDelete(DeleteBehavior.Restrict);
        }
    }

   
}
