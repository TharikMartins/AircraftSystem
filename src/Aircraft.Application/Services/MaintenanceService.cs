using Aircraft.Application.Interfaces;
using Aircraft.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aircraft.Application.Services
{
    public class MaintenanceService : IMaintenanceService
    {
        private readonly IRepository<Maintenance> _repository;
        public MaintenanceService(IRepository<Maintenance> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Maintenance>> Get(Guid userId)
        {
            return await _repository.Get(userId);
        }

        public async Task<bool> Insert(Maintenance maintenance)
        {
            return await _repository.Insert(maintenance);
        }
    }
}
