using Aircraft.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aircraft.Application.Interfaces
{
    public interface IMaintenanceService
    {
        Task<IEnumerable<Maintenance>> Get(Guid userId);
        Task<bool> Insert(Maintenance maintenance);
    }
}
