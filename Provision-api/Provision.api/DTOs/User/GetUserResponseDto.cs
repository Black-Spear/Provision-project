namespace Provision.api.Dtos.LoginQrCode
{
    public class GetUserResponseDto
    {
        public int Id { get; set; }
        public string UserName { get; set; } = "not set";
        public string Password { get; set; } = "default";
    }
}
