using CQRS.Domain.Entities;
using CQRS.Infrastructure.EntityConfiguration;
using Microsoft.EntityFrameworkCore;

namespace CQRS.Infrastructure.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Member> Members { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new MemberConfiguration());
    }
}
