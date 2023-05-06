using Account.ApplicationServices;
using Account.Client;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Account.Api.Controllers.v1
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class AccountsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public AccountsController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost(Name = "CreateAccount")]
        public async Task<AccountDto> Create(CreateAccount model, CancellationToken cancellationToken)
        {
            var command = new CreateAccountCommand { Email = model.Email};
            var result = await _mediator.Send(command, cancellationToken);
            var resultDto = _mapper.Map<AccountDto>(result);

            return resultDto;
        }

        [HttpDelete("{idOrEmail}", Name = "DeleteAccount")]
        public async Task Delete(string idOrEmail, CancellationToken cancellationToken)
        {
            if (Guid.TryParse(idOrEmail, out var id))
            {
                await _mediator.Send(new DeleteAccountByIdCommand { Id = id }, cancellationToken);
            }
            else
            {
                 await _mediator.Send(new DeleteAccountByEmailCommand { Email = idOrEmail }, cancellationToken);
            }
        }


        [HttpGet("{idOrEmail}", Name = "GetAccount")]
        public async Task<AccountDto> Get(string idOrEmail, CancellationToken cancellationToken)
        {
            Domain.Account result;
            if(Guid.TryParse(idOrEmail, out var id))
            {
                result = await _mediator.Send(new GetAccountByIdQuery { Id = id }, cancellationToken);
            }
            else
            {
                result = await _mediator.Send(new GetAccountByEmailQuery { Email = idOrEmail}, cancellationToken);
            }
            
            var resultDto = _mapper.Map<AccountDto>(result);

            return resultDto;
        }

        [HttpPut("{id}", Name = "UpdateAccount")]
        public async Task Update(Guid id, UpdateAccount updateAccount, CancellationToken cancellationToken)
        {
            var command = new UpdateAccountCommand { Id = id, Email = updateAccount.Email };
            await _mediator.Send(command, cancellationToken);
        }

    }
}
