namespace Account.Domain
{
    public interface IAccountReader
    {
        public Task<Account> Get(Guid id, CancellationToken cancellation = default);
        public Task<Account> Get(string email, CancellationToken cancellation = default);
    }
}
