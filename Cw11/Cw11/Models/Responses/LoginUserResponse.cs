namespace Cw11.Models.Responses;

public class LoginUserResponse
{
    public string JwtToken { get; set; }
    public string RefToken { get; set; }
}