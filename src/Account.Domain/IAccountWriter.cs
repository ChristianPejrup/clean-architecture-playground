namespace Account.Domain
{
    public interface IAccountWriter
    {
        public Task CreateAccount(Account account);
        public Task UpdateAccount(Account account);
        public Task DeleteAccount(Account account);
    }
}
