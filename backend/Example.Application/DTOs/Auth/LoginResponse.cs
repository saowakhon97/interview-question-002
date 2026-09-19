namespace Example.Application.DTOs.Auth;

public class LoginResponse
{
    public string AccessToken { get; set; } = string.Empty;

    public string Username { get; set; } = string.Empty;

    // public string DisplayName { get; set; } = string.Empty;
}