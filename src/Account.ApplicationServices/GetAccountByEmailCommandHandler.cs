using Account.Domain;
using MediatR;

namespace Account.ApplicationServices
{
    public class GetAccountByEmailCommandHandler : IRequestHandler<GetAccountByEmailQuery, Domain.Account>
    {
        private readonly IAccountReader _accountReader;

        public GetAccountByEmailCommandHandler(IAccountReader accountReader)
        {
            _accountReader = accountReader;
        }

        public async Task<Domain.Account> Handle(GetAccountByEmailQuery request, CancellationToken cancellationToken)
        {
            return await _accountReader.Get(request.Email, cancellationToken);
        }
    }
}
