namespace Account.Client
{
    public interface IAccountClient
    {
        Task<AccountDto> GetAccountAsync(Guid accountId, CancellationToken cancellationToken = default);
        Task<AccountDto> GetAccountAsync(string accountId, CancellationToken cancellationToken = default);
    }
}
