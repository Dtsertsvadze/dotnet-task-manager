using Microsoft.EntityFrameworkCore;
using TaskManager.Application.Contracts;
using TaskManager.Domain.Entities;

namespace TaskManager.Infrastructure;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options), IApplicationDbContext
{
    public DbSet<ApplicationUser> Users { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}