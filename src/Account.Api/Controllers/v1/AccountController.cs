using Account.Api.Models;
using Account.ApplicationServices;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Account.Api.Controllers.v1
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountApplicationService _accountApplicationService;
        private readonly IMapper _mapper;

        public AccountsController(IAccountApplicationService accountApplicationService, IMapper mapper)
        {
            _accountApplicationService = accountApplicationService;
            _mapper = mapper;
        }

        [HttpGet("{id}", Name="GetAccount")]
        public async Task<AccountDto> Get([ValidateGuid] Guid id, CancellationToken cancellationToken)
        {
            var result = await _accountApplicationService.GetAccount(id, cancellationToken);
            var resultDto = _mapper.Map<AccountDto>(result);

            return resultDto;
        }
    }
}
