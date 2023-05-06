using Account.Domain;
using MediatR;

namespace Account.ApplicationServices
{
    public record DeleteAccountByEmailCommandHandler : IRequestHandler<DeleteAccountByEmailCommand>
    {
        private readonly IAccountWriter _accountWriter;

        public DeleteAccountByEmailCommandHandler(IAccountWriter accountWriter)
        {
            _accountWriter = accountWriter;
        }
        public async Task Handle(DeleteAccountByEmailCommand request, CancellationToken cancellationToken)
        {
            await _accountWriter.Delete(request.Email, cancellationToken);
        }
    }
}
