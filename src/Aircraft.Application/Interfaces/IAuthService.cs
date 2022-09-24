using Aircraft.Domain;

namespace Aircraft.Application.Interfaces
{
    public interface IAuthService
    {
        string GenerateToken(UserProfile user);
    }
}
