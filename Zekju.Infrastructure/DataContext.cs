using Zekju.Domain.Model;
using Microsoft.Extensions.Configuration;

namespace Zekju.Infrastructure;

using Microsoft.EntityFrameworkCore;

public class DataContext : DbContext
{
    public DataContext() { }
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }

    public virtual DbSet<Route> Routes { get; set; } = null!;
    public virtual DbSet<Flight> Flights { get; set; } = null!;
    public virtual DbSet<Subscription> Subscriptions { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
    }
}
