namespace Example.Application.DTOs.Auth;

public class RegisterRequest
{
    public string Username { get; set; } = string.Empty;

    // public string DisplayName { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;

    public string ConfirmPassword { get; set; } = string.Empty;
}