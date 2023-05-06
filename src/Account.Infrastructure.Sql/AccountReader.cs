using Account.Domain;
using Shared.Exceptions;

namespace Account.Infrastructure.Sql
{
    public class AccountReader : IAccountReader
    {
        public async Task<Domain.Account> Get(Guid id, CancellationToken cancellation = default)
        {
            var account = await GetFromDatabase(id.ToString());
            
            return account ?? throw new NotFoundException(id);
        }

        public async Task<Domain.Account> Get(string email, CancellationToken cancellation = default)
        {
            var account = await GetFromDatabase(email);

            return account ?? throw new NotFoundException(email);
        }

        //TODO: Implement database layer
        private Task<Domain.Account> GetFromDatabase(string idOrEmail, CancellationToken cancellation = default)
        {
            var isId = Guid.TryParse(idOrEmail, out var id);

            return Task.FromResult(
                new Domain.Account
                {
                    Id = isId ? id : Guid.NewGuid(),
                    Email = isId ? String.Empty : idOrEmail
                    
                });;
        }
    }
}
