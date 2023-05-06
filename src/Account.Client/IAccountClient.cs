namespace Account.Client
{
    public interface IAccountClient
    {
        Task<AccountDto> Create(CreateAccount createAccount, CancellationToken cancellationToken = default);
        Task Delete(Guid accountId, CancellationToken cancellationToken = default);
        Task Delete(string accountIdOrEmail, CancellationToken cancellationToken = default);
        Task<AccountDto> Get(Guid accountId, CancellationToken cancellationToken = default);
        Task<AccountDto> Get(string accountId, CancellationToken cancellationToken = default);
        Task Update(Guid accountId, UpdateAccount updateAccount, CancellationToken cancellationToken = default);
    }
}
