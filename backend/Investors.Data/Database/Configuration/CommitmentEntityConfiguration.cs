using Investors.Data.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Investors.Data.Database.Configuration;

public class CommitmentEntityConfiguration : IEntityTypeConfiguration<Commitment>
{
    public void Configure(EntityTypeBuilder<Commitment> builder)
    {
        builder.ToTable(nameof(Commitment));
        builder.Property(x => x.Currency).IsRequired();
    }
}
