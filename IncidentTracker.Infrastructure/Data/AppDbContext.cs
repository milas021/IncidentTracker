using IncidentTracker.Domain.Entitties;
using Microsoft.EntityFrameworkCore;

namespace IncidentTracker.Infrastructure.Data;
public class AppDbContext : DbContext {
    public DbSet<Asset> Assets => Set<Asset>();
    public DbSet<Incident> Incidents => Set<Incident>();
    public DbSet<IncidentTimeline> IncidentTimelines => Set<IncidentTimeline>();
    public DbSet<User> Users => Set<User>();
    public DbSet<Team> Teams => Set<Team>();
    public DbSet<WorkOrder> WorkOrders => Set<WorkOrder>();

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
}

