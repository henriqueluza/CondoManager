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
    
    public DbSet <Employee> Employees { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Visitor>()
            .HasOne(v => v.AuthorizedBy)
            .WithMany()
            .HasForeignKey(v => v.AuthorizedById)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<AccessLog>()
            .HasOne(a => a.Visitor)
            .WithMany()
            .HasForeignKey(a => a.VisitorId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<AccessLog>()
            .HasOne(a => a.Employee)
            .WithMany()
            .HasForeignKey(a => a.EmployeeId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
