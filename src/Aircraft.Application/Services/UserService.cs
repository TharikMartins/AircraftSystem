using Aircraft.Application.Interfaces;
using Aircraft.Domain;
using System.Threading.Tasks;

namespace Aircraft.Application.Services
{

    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<UserProfile> GetByLoginCredentials(string login, string password)
        {
            UserProfile user = await _repository.GetByLoginCredentials(login, password);

            if (user != null)
                return user;

            UserProfile userProfile = new UserProfile { Login = login, Password = password };

            userProfile.Id = await _repository.Insert(userProfile);

            return userProfile;
        }

    }
}