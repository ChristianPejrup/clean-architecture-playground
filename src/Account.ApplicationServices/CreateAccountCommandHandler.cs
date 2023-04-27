using Account.Domain;
using MediatR;

namespace Account.ApplicationServices
{
    public class CreateAccountCommandHandler : IRequestHandler<CreateAccountCommand, Domain.Account>
    {
        private readonly IAccountWriter _accountWriter;

        public CreateAccountCommandHandler(IAccountWriter accountWriter)
        {
            _accountWriter = accountWriter;
        }

        public async Task<Domain.Account> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
        {
            var account = new Domain.Account { 
                Id = request.Id,
                Email = request.Email 
            };

            return await _accountWriter.Create(account, cancellationToken);
        }
    }
}
