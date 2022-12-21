using AutoMapper;

namespace Account.Api.Controllers.v1
{
    public class MappingProfileV1 : Profile
    {
        public MappingProfileV1()
        {
            CreateMap<Domain.Account, AccountDto>();
        }
    }
}
