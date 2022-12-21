namespace Account.ApplicationServices
{
    public interface IAccountApplicationService
    {
        Task<Domain.Account> CreateAccount(Domain.Account account, CancellationToken cancellationToken);
        Task<Domain.Account> GetAccount(Guid id, CancellationToken cancellationToken);
    }
}