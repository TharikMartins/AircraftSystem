using Aircraft.Domain;
using System.Threading.Tasks;

namespace Aircraft.Application.Interfaces
{
    public interface IStageService
    {
        Task<bool> Insert(Stage stage);
    }
}
