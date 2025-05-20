using Investors.Data.Domain;
using Microsoft.EntityFrameworkCore;

namespace Investors.Data.Database;

public class InvestorContext(DbContextOptions<InvestorContext> options) 
    : DbContext(options)
{
    public DbSet<Investor> Investor { get; set; }
    public DbSet<Commitment> Commitment { get; set; }
    public DbSet<AssetClass> AssetClass { get; set; }
    public DbSet<Country> Location { get; set; }
    public DbSet<InvestorType> InvestorType { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(InvestorContext).Assembly);
        base.OnModelCreating(modelBuilder);        
    }
}
