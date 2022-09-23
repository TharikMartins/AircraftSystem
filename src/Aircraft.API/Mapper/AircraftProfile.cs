using Aircraft.API.Request;
using Aircraft.API.Response;
using Aircraft.Domain;
using AutoMapper;

namespace Aircraft.API.Mapper
{
    internal class AircraftProfile : Profile
    {
        public AircraftProfile()
        {
            CreateMap<Maintenance, MaintenanceResponse>();
            CreateMap<MaintenanceRequest, Maintenance>();
            CreateMap<StageRequest, Stage>();
        }
    }
}
