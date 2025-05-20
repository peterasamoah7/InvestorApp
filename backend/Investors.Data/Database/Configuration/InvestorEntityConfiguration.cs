using Investors.Data.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Investors.Data.Database.Configuration;

public class InvestorEntityConfiguration : IEntityTypeConfiguration<Investor>
{
    public void Configure(EntityTypeBuilder<Investor> builder)
    {
        builder.ToTable(nameof(Investor));
        builder.Property(x => x.Name).IsRequired();
    }
}
