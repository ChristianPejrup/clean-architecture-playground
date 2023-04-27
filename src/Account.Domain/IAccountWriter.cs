namespace Account.Domain
{
    public interface IAccountWriter
    {
        public Task<Account> Create(Account account, CancellationToken cancellation = default);
        public Task Update(Account account, CancellationToken cancellation = default);
        public Task Delete(Guid id, CancellationToken cancellation = default);
    }
}
