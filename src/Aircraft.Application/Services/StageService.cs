using Aircraft.Application.Interfaces;
using Aircraft.Domain;
using System;
using System.Threading.Tasks;

namespace Aircraft.Application.Services
{
    public class StageService : IStageService
    {
        private readonly IRepository<Stage> _repository;

        public StageService(IRepository<Stage> repository)
        {
           _repository = repository;
        }

        public async Task<bool> Insert(Stage stage)
        {
            return await _repository.Insert(stage);
        }
    }
}
