using Microsoft.EntityFrameworkCore;
using CondoManager.Domain.Entities;

namespace CondoManager.Infrastructure.Data;

public class CondoManagerContext : DbContext
{
    public CondoManagerContext(DbContextOptions<CondoManagerContext> options)
        : base(options) {}
    
    public DbSet<Member> Members { get; set; }
    public DbSet<Visitor> Visitors { get; set; }
    public DbSet<AccessLog> AccessLogs { get; set; }
    public DbSet<Condominium> Condominiums { get; set; }
    public DbSet<User> Users { get; set; }
}
