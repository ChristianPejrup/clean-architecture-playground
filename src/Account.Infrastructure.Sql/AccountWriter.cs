using Account.Domain;

namespace Account.Infrastructure.Sql
{
    public class AccountWriter : IAccountWriter
    {
        public Task<Domain.Account> Create(Domain.Account account, CancellationToken cancellation = default)
        {
            return Task.FromResult(account);
        }

        public Task Delete(Guid id, CancellationToken cancellation = default)
        {
            return Task.CompletedTask;
        }

        public Task Update(Domain.Account account, CancellationToken cancellation = default)
        {
            return Task.CompletedTask;
        }
    }
}