using Aircraft.Application.Interfaces;
using Aircraft.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aircraft.Infrastructure.Repositories
{
    public class UserRepository : IRepository<UserProfile>
    {
        public Task<IEnumerable<UserProfile>> Get(Guid Id)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> Insert(UserProfile Model)
        {
            throw new System.NotImplementedException();
        }
    }
}
