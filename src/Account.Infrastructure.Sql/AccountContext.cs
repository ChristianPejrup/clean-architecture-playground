using Microsoft.EntityFrameworkCore;

namespace Account.Infrastructure.Sql
{
    internal class AccountContext : DbContext
    {
        public AccountContext(DbContextOptions<AccountContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AccountMap());
        }

        public DbSet<Domain.Account> Accounts { get; set; }
    }
}
