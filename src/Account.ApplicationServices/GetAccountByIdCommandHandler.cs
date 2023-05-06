using Account.Domain;
using MediatR;

namespace Account.ApplicationServices
{
    public class GetAccountByIdCommandHandler : IRequestHandler<GetAccountByIdQuery, Domain.Account>
    {
        private readonly IAccountReader _accountReader;

        public GetAccountByIdCommandHandler(IAccountReader accountReader)
        {
            _accountReader = accountReader;
        }

        public async Task<Domain.Account> Handle(GetAccountByIdQuery request, CancellationToken cancellationToken)
        {
            return await _accountReader.Get(request.Id, cancellationToken);
        }
    }
}
