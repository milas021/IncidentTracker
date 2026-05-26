using IncidentTracker.Application.EventHandlers;
using IncidentTracker.Domain.Entitties;
using Microsoft.EntityFrameworkCore;

namespace IncidentTracker.Infrastructure.Data;
public class AppDbContext(DbContextOptions<AppDbContext> options, DomainEventDispatcher eventDispatcher) : DbContext(options) {
    public DbSet<Asset> Assets => Set<Asset>();
    public DbSet<Incident> Incidents => Set<Incident>();
    public DbSet<IncidentTimeline> IncidentTimelines => Set<IncidentTimeline>();
    public DbSet<User> Users => Set<User>();
    public DbSet<Team> Teams => Set<Team>();
    public DbSet<WorkOrder> WorkOrders => Set<WorkOrder>();



    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) {

        var domainEventEntities = ChangeTracker.Entries<Entity>()
        .Select(po => po.Entity)
        .Where(po => po.GetEvents().Any())
        .ToArray();

        foreach (var entity in domainEventEntities) {
            var events = entity.GetEvents().ToArray();

            foreach (var domainEvent in events) {
                eventDispatcher.DispatchAsync(domainEvent);
            }

            entity.ClearDomainEvents();
        }


        return base.SaveChangesAsync(cancellationToken);
    }
}

