using Aircraft.Application.Interfaces;
using Aircraft.Domain;
using Aircraft.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Aircraft.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AircraftContext _context;

        public UserRepository(AircraftContext context)
        {
            _context = context;
        }

        public async Task<UserProfile> GetByLoginCredentials(string login, string password)
        {
            return await _context.Users.
                FirstOrDefaultAsync(u => u.Login == login && u.Password == password);
        }

        public async Task<Guid> Insert(UserProfile model)
        {
            await _context.Users
                .AddAsync(model);

            await _context.SaveChangesAsync();

            return model.Id;
        }
    }
}
