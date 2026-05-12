using IncidentTracker.Application.Interfaces;
using IncidentTracker.Application.Settings;
using IncidentTracker.Infrastructure.Data;
using IncidentTracker.Infrastructure.Repositories;
using IncidentTracker.Infrastructure.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace IncidentTracker.Infrastructure.DI;
public static class InfrastructureRegistration {
    public static void AddInfrastructure(this IServiceCollection services) {

        services.AddRepositories();
    }



    public static void AddRepositories(this IServiceCollection services) {
        var setting = services.BuildServiceProvider().GetService<IOptions<DbSettings>>().Value;
        var setting2 = services.BuildServiceProvider().GetService<IOptions<TokenSettings>>().Value;


        services.AddDbContext<AppDbContext>(options => {
            options.UseSqlServer(setting.ConnectionString);
        });

        services.AddScoped<IAssetRepository, AssetRepository>();
        services.AddScoped<IIncidentRepository, IncidentRepository>();
        services.AddScoped<IIncidentTimelineRepository, IncidentTimelineRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<ITeamRepository, TeamRepository>();
        services.AddScoped<IWorkOrderRepository, WorkOrderRepository>();

    }
}
