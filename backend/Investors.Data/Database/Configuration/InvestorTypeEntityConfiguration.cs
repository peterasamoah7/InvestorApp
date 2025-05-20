using Investors.Data.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Investors.Data.Database.Configuration;

public class InvestorTypeEntityConfiguration : IEntityTypeConfiguration<InvestorType>
{
    public void Configure(EntityTypeBuilder<InvestorType> builder)
    {
        builder.ToTable(nameof(InvestorType));
        builder.HasIndex(x => x.TypeOfInvestor).IsUnique();
    }
}
