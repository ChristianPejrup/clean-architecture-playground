using Account.Domain;

namespace Account.Infrastructure.Sql
{
    public class AccountWriter : IAccountWriter
    {
        public Task CreateAccount(Domain.Account account)
        {
            return Task.CompletedTask;
        }

        public Task DeleteAccount(Domain.Account account)
        {
            return Task.CompletedTask;
        }

        public Task UpdateAccount(Domain.Account account)
        {
            return Task.CompletedTask;
        }
    }
}