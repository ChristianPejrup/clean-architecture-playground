using Account.Domain;
using MediatR;

namespace Account.ApplicationServices
{
    public record DeleteAccountByIdCommandHandler : IRequestHandler<DeleteAccountByIdCommand>
    {
        private readonly IAccountWriter _accountWriter;

        public DeleteAccountByIdCommandHandler(IAccountWriter accountWriter)
        {
            _accountWriter = accountWriter;
        }
        public async Task Handle(DeleteAccountByIdCommand request, CancellationToken cancellationToken)
        {
            await _accountWriter.Delete(request.Id, cancellationToken);
        }
    }
}
