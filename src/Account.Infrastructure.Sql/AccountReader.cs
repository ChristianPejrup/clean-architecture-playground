using Account.Domain;
using Shared.Exceptions;

namespace Account.Infrastructure.Sql
{
    public class AccountReader : IAccountReader
    {
        public async Task<Domain.Account> GetAccount(Guid id)
        {
            var account = await GetFromDatabase(id);
            
            return account ?? throw new NotFoundException(id);
        }

        private Task<Domain.Account> GetFromDatabase(Guid id)
        {
            return Task.FromResult(new Domain.Account { Id = id });
        }
    }
}
