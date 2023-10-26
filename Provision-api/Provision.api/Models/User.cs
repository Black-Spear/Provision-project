namespace Provision.api.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; } = "not set";
        public string Password { get; set; } = "default";
    }
}