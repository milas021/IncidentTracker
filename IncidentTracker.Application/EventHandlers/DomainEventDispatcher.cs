using IncidentTracker.Domain.Events;
using Microsoft.Extensions.DependencyInjection;

namespace IncidentTracker.Application.EventHandlers;
public class DomainEventDispatcher {
    private readonly IServiceProvider _serviceProvider;

    public DomainEventDispatcher(IServiceProvider serviceProvider) {
        _serviceProvider = serviceProvider;
    }

    public async Task DispatchAsync(IEnumerable<IDomainEvent> domainEvents) {
        foreach (var domainEvent in domainEvents) {
            var handlerType = typeof(IDomainEventHandler<>).MakeGenericType(domainEvent.GetType());
            var handlers = (IEnumerable<object>)_serviceProvider.GetServices(handlerType);

            foreach (dynamic handler in handlers) {
                await handler.HandleAsync((dynamic)domainEvent);
            }
        }
    }

    public async Task DispatchAsync(IDomainEvent domainEvent) {

        var handlerType = typeof(IDomainEventHandler<>).MakeGenericType(domainEvent.GetType());
        var handlers = (IEnumerable<object>)_serviceProvider.GetServices(handlerType);

        foreach (dynamic handler in handlers) {
            await handler.HandleAsync((dynamic)domainEvent);
        }

    }
}

