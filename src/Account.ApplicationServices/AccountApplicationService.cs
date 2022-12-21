using Account.Domain;

namespace Account.ApplicationServices
{
    public class AccountApplicationService : IAccountApplicationService
    {
        private readonly IAccountReader _accountReader;
        private readonly IAccountWriter _accountWriter;

        public AccountApplicationService(IAccountReader accountReader, IAccountWriter accountWriter)
        {
            _accountReader = accountReader;
            _accountWriter = accountWriter;
        }

        public async Task<Domain.Account> GetAccount(Guid id, CancellationToken cancellationToken)
        {
            return await _accountReader.GetAccount(id);
        }

        public async Task<Domain.Account> CreateAccount(Domain.Account account, CancellationToken cancellationToken)
        {
            await _accountWriter.CreateAccount(account);

            return account;
        }
    }
}