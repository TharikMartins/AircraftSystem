using Aircraft.Application.Interfaces;
using Aircraft.Application.Services;
using Aircraft.Domain;
using Aircraft.Infrastructure.Context;
using Aircraft.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Aircraft.CrossCutting
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddRepository(this IServiceCollection services, IConfiguration configuration)
        {
            return services.AddScoped<IRepository<UserProfile>, UserRepository>()
                .AddScoped<IRepository<UserProfile>, UserRepository>()
                .AddScoped<IRepository<Maintenance>, MaintenanceRepository>()
                .AddScoped<IRepository<Stage>, StageRepository>()
                .AddDbContext<AircraftContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            return services.AddTransient<IMaintenanceService, MaintenanceService>()
                .AddTransient<IStageService, StageService>();
        }

    }
}
