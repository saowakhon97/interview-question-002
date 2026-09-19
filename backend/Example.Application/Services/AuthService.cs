using Example.Application.DTOs.Auth;
using Example.Application.Interfaces;
using Example.Domain.Entities;

namespace Example.Application.Services;

public class AuthService(IUserRepository userRepository, IPasswordService passwordService,IJwtService jwtService) : IAuthService
{
    public async Task RegisterAsync(RegisterRequest request)
    {
        if (request.Password != request.ConfirmPassword)
        {
            throw new Exception("Password and Confirm Password do not match.");
        }

        var existingUser =
            await userRepository.GetByUsernameAsync(request.Username);

        if (existingUser != null)
        {
            throw new Exception("Username already exists.");
        }

        var user = new User
        {
            Id = Guid.NewGuid(),
            Username = request.Username,
            // DisplayName = request.DisplayName,
            PasswordHash = passwordService.HashPassword(request.Password),
            CreatedAt = DateTime.UtcNow
        };

        await userRepository.AddAsync(user);

        await userRepository.SaveChangesAsync();
    }
    
    public async Task<LoginResponse> LoginAsync(LoginRequest request)
    {
        var user = await userRepository.GetByUsernameAsync(request.Username);

        if (user == null)
            throw new Exception("Invalid username or password.");

        var valid = passwordService.VerifyPassword(
            request.Password,
            user.PasswordHash);

        if (!valid)
            throw new Exception("Invalid username or password.");

        return new LoginResponse
        {
            AccessToken = jwtService.GenerateToken(user),
            Username = user.Username,
            // DisplayName = user.DisplayName
        };
    }
}