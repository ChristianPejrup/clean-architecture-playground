using MediatR;

namespace Account.ApplicationServices
{
    public record AccountQuery : IRequest<Domain.Account>
    {
        public Guid Id { get; init; }
    }
}
