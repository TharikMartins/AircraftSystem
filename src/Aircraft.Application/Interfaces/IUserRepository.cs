using Aircraft.Domain;
using System;
using System.Threading.Tasks;

namespace Aircraft.Application.Interfaces
{
    public interface IUserRepository
    {
        Task<UserProfile> GetByLoginCredentials(string login, string password);
        Task<Guid> Insert(UserProfile user);
    }
}
