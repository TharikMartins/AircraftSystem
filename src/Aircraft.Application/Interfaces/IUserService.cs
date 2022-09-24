using Aircraft.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Aircraft.Application.Interfaces
{
    public interface IUserService
    {
        Task<UserProfile> GetByLoginCredentials(string login, string password);
    }
}
