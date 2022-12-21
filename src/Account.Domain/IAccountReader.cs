namespace Account.Domain
{
    public interface IAccountReader
    {
        public Task<Account> GetAccount(Guid id);
    }
}
