using Aircraft.Application.Interfaces;
using Aircraft.Domain;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;

namespace Aircraft.Application.Services
{
    public class StageService : IStageService
    {
        private readonly IRepository<Stage> _repository;
        private readonly IRepository<Maintenance> _maintenanceRepo;

        public StageService(IRepository<Stage> repository, IRepository<Maintenance> maintenanceRepo)
        {
            _repository = repository;
            _maintenanceRepo = maintenanceRepo;
        }

        public async Task<bool> Insert(IEnumerable<Stage> stages)
        {
            foreach (var stage in stages)
            {
             bool result = await _repository.Insert(stage);

                if (!result)
                    return false;

                await _maintenanceRepo.Update(stage.MaintenanceId);

            }

            return true;
        }

        public async Task<IEnumerable<Stage>> Get(Guid maintenanceId)
        {
            return await _repository.Get(maintenanceId);
        }
    }
}
