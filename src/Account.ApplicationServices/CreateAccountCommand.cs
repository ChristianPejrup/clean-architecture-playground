using MediatR;

namespace Account.ApplicationServices
{
    public record CreateAccountCommand : IRequest<Domain.Account>
    {
        public Guid Id { get; } = Guid.NewGuid();
        public string Email { get; set; }
    }
}
