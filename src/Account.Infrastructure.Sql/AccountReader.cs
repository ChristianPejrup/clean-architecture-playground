using Account.Domain;
using Shared.Exceptions;

namespace Account.Infrastructure.Sql
{
    public class AccountReader : IAccountReader
    {
        public async Task<Domain.Account> Get(Guid id, CancellationToken cancellation = default)
        {
            var account = await GetFromDatabase(id);
            
            return account ?? throw new NotFoundException(id);
        }

        private Task<Domain.Account> GetFromDatabase(Guid id, CancellationToken cancellation = default)
        {
            return Task.FromResult(new Domain.Account { Id = id });
        }
    }
}
