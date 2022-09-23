using Aircraft.Application.Interfaces;
using Aircraft.Domain;
using Aircraft.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aircraft.Infrastructure.Repositories
{
    public class StageRepository : IRepository<Stage>
    {
        private readonly AircraftContext _context;
        public StageRepository(AircraftContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Stage>> Get(Guid Id)
        {
            return await _context.Stages
                .Where(s => s.Maintenance.Id == Id)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<bool> Insert(Stage model)
        {
            await _context.Stages
                .AddAsync(model);

            return await _context.SaveChangesAsync() > 0;
        }
    }
}
