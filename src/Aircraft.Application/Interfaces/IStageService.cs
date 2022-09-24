using Aircraft.Domain;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;

namespace Aircraft.Application.Interfaces
{
    public interface IStageService
    {
        Task<bool> Insert(IEnumerable<Stage> stage);
        Task<IEnumerable<Stage>> Get(Guid maintenanceId);
    }
}
