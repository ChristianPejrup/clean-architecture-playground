using Account.Domain;
using MediatR;

namespace Account.ApplicationServices
{
    public record DeleteAccountCommandHandler : IRequestHandler<DeleteAccountCommand>
    {
        private readonly IAccountWriter _accountWriter;

        public DeleteAccountCommandHandler(IAccountWriter accountWriter)
        {
            _accountWriter = accountWriter;
        }
        public async Task Handle(DeleteAccountCommand request, CancellationToken cancellationToken)
        {
            await _accountWriter.Delete(request.Id, cancellationToken);
        }
    }
}
