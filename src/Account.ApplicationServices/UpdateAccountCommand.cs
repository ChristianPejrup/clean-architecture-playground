using MediatR;

namespace Account.ApplicationServices
{
    public record UpdateAccountCommand : IRequest
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
    }
}
