using GermanCards.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace GermanCards.Data;

public class AppContext : DbContext
{
    public DbSet<Card> Cards { get; set; } = null!;
    public AppContext(DbContextOptions<AppContext> options) : base(options) { } 
}