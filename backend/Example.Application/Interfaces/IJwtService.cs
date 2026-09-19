using Example.Domain.Entities;

namespace Example.Application.Interfaces;

public interface IJwtService
{
    string GenerateToken(User user);
}