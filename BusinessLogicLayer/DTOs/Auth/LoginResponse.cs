namespace BusinessLogicLayer.DTOs.Auth
{
    public class LoginResponse
    {
        public int UserId { get; set; }
        public string Username { get; set; }

        public string JwtToken { get; set; }

        public DateTime ExpiresAt { get; set; }
    }
}
