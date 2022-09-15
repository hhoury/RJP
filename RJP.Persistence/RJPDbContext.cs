using Microsoft.EntityFrameworkCore;
using RJP.Domain;
using RJP.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RJP.Persistence
{
    public class RJPDbContext : DbContext
    {
        public RJPDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(RJPDbContext).Assembly);
        }
        public virtual async Task<int> SaveChangesAsync(string username = "SYSTEM")
        {
            foreach (var entry in base.ChangeTracker.Entries<BaseDomainEntity>()
                .Where(q => q.State == EntityState.Added || q.State == EntityState.Modified))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.DateCreated = DateTime.Now;
                }
                else
                {
                    if (entry.State == EntityState.Modified)
                    {
                        entry.Entity.LastModifiedDate = DateTime.Now;
                    }
                }
            }

            var result = await base.SaveChangesAsync();
            return result;
        }
    }
}
