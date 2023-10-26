using Provision.api.Dtos.LoginQrCode;

namespace Provision.api
{
    public class AutoMapperProfile :Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, GetUserResponseDto>();
            CreateMap<AddUserRequestDto,User >();

        }
    }
}
