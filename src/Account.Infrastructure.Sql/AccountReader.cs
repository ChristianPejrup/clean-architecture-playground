using Account.Domain;

namespace Account.Infrastructure.Sql
{
    public class AccountReader : IAccountReader
    {
        public Task<Domain.Account> GetAccount(Guid id)
        {
            return Task.FromResult(new Domain.Account { Id = id });
        }
    }
}
