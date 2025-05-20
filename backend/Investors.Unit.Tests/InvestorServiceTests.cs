using FluentAssertions;
using Investors.BL.Models;
using Investors.BL.Services;
using Investors.Data.Database;
using Investors.Data.Domain;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Investors.Unit.Tests;

public class InvestorServiceTests : IDisposable
{
    private InvestorContext context;

    public void Dispose()
    {
        context.Dispose();
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            if (context != null)
            {
                context.Dispose();
                context = null;
            }
        }
    }

    [SetUp]
    public void Setup()
    {
        var contextOptions = new DbContextOptionsBuilder<InvestorContext>()
            .UseInMemoryDatabase("InvestorDB")
            .ConfigureWarnings(b => b.Ignore(InMemoryEventId.TransactionIgnoredWarning))
            .Options;

        context = new InvestorContext(contextOptions);

        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();

        context.Add(new Investor 
        {
            Name = "Test Investor", 
            DateAdded = DateTime.Parse("2025-05-20"),
            InvestorType = new InvestorType { TypeOfInvestor = "Test Bank" },
            Country = new Country { Name = "United Kingdom" },
            Commitments = [
                new Commitment 
                {
                    Amount = 1000,
                    Currency = "GBP",
                    AssetClass = new AssetClass { Name = "TestAsset" }
                },
                new Commitment 
                {
                    Amount = 1000,
                    Currency = "GBP",
                    AssetClass = new AssetClass { Name = "TestAsset2" }
                }
            ]
        });

        context.SaveChanges();
    }

    [Test]
    public async Task Test_Get_All_Investors()
    {
        var sut = new InvestorService(context);

        var result = await sut.GetAllInvestorsAsync(null, new PagedRequest());

        result.Should().NotBeNull();
        result.Items.Should().HaveCount(1);
    }

    [Test]
    public async Task Test_Get_Commitment_Summary()
    {
        var sut = new InvestorService(context);

        var result = await sut.GetCommitmentSummariesAsync(1);

        result.Should().NotBeNull();
        result.Count.Should().Be(3);
    }

    [Test]
    public async Task Test_Get_Investor_Commitments()
    {
        var sut = new InvestorService(context);

        var result = await sut.GetInvestorCommitment(1, null, new PagedRequest());

        result.Should().NotBeNull();
        result.Items.Count.Should().Be(2);
    }
}
