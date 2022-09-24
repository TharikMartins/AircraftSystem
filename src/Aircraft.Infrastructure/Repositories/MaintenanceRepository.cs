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
    public class MaintenanceRepository : IRepository<Maintenance>
    {
        private readonly AircraftContext _context;
        public MaintenanceRepository(AircraftContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Maintenance>> Get(Guid Id)
        {
            return await _context.Maintenances
                .Where(m => m.User.Id == Id)
                .Include(m => m.Stages)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<bool> Insert(Maintenance model)
        {
            await _context.Maintenances
                 .AddAsync(model);

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Update(Guid id)
        {
            var model = _context.Maintenances
                .FirstOrDefault(s => s.Id == id);

            if (model == null)
                return false;

            model.Status = true;

            _context.Maintenances.Update(model);

            return await _context.SaveChangesAsync() > 0;
        }
    }
}
