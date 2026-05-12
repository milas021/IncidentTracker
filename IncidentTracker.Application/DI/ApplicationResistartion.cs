using IncidentTracker.Application.EventHandlers;
using IncidentTracker.Application.EventHandlers.Handlers;
using IncidentTracker.Application.Services;
using IncidentTracker.Domain.Events;
using Microsoft.Extensions.DependencyInjection;

namespace IncidentTracker.Application.DI;
public static class ApplicationResistartion {
    public static void AddApplication(this IServiceCollection services) {
        services.AddEventHandlers();
        services.AddServices();
    }


    private static void AddEventHandlers(this IServiceCollection services) {
        services.AddScoped<DomainEventDispatcher>();
        services.AddScoped<IDomainEventHandler<IncidentAcknowledgedEvent>, IncidentAcknowledgedEventHandler>();

    }

    private static void AddServices(this IServiceCollection services) {
        services.AddScoped<AssetService>();
        services.AddScoped<IncidentService>();
        services.AddScoped<UserService>();
        services.AddScoped<TeamService>();
        services.AddScoped<WorkOrderService>();

    }
}
