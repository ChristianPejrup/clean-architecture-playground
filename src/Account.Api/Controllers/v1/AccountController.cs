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

        [HttpGet(Name = "CreateAccount")]
        public async Task<AccountDto> Create(string email, CancellationToken cancellationToken)
        {
            var command = new CreateAccountCommand { Email = email };
            var result = await _mediator.Send(command, cancellationToken);
            var resultDto = _mapper.Map<AccountDto>(result);

            return resultDto;
        }

        [HttpGet("{id}", Name = "DeleteAccount")]
        public async Task Delete(Guid id, CancellationToken cancellationToken)
        {
            var command = new DeleteAccountCommand { Id = id };
            await _mediator.Send(command, cancellationToken);
        }


        [HttpGet("{id}", Name = "GetAccount")]
        public async Task<AccountDto> Get(Guid id, CancellationToken cancellationToken)
        {
            var query = new AccountQuery { Id = id };
            var result = await _mediator.Send(query, cancellationToken);
            var resultDto = _mapper.Map<AccountDto>(result);

            return resultDto;
        }

        [HttpGet("{id}", Name = "DeleteAccount")]
        public async Task Delete(Guid id, string email, CancellationToken cancellationToken)
        {
            var command = new  { Id = id };
            await _mediator.Send(command, cancellationToken);
        }
    }
}
