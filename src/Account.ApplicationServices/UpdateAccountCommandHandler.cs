using Account.Domain;
using MediatR;

namespace Account.ApplicationServices
{
    public record UpdateAccountCommandHandler : IRequestHandler<UpdateAccountCommand>
    {
        private readonly IAccountReader _accountReader;
        private readonly IAccountWriter _accountWriter;

        public UpdateAccountCommandHandler(IAccountReader accountReader, IAccountWriter accountWriter)
        {
            _accountReader = accountReader;
            _accountWriter = accountWriter;
        }
        public async Task Handle(UpdateAccountCommand request, CancellationToken cancellationToken)
        {
            var account = await _accountReader.Get(request.Id, cancellationToken);

            account.Email = request.Email;

            await _accountWriter.Update(account, cancellationToken);
        }
    }
}
