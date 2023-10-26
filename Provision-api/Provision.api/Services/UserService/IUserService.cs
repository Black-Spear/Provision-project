namespace Provision.api.Services.UserService;

public interface IUserService
{
    Task<ServiceResponse<List<GetUserResponseDto>>> GetAllUsers();
    Task<ServiceResponse<GetUserResponseDto>> GetUserById(int id);
    Task<ServiceResponse<GetUserResponseDto>> GetUserByString(string targetString);
    Task<ServiceResponse<List<GetUserResponseDto>>> AddUser(AddUserRequestDto newLoginQrCode);
    Task<ServiceResponse<List<GetUserResponseDto>>> DeleteUserById(int id);
    Task<ServiceResponse<GetUserResponseDto>> Login(string targetQrString, string password);
}
