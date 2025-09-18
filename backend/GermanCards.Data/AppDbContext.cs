using GermanCards.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace GermanCards.Data;

public class AppDbContext : DbContext
{
    public DbSet<Card> Cards { get; set; } = null!;
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { } 
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}