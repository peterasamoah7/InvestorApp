using Investors.BL.Extensions;
using Investors.BL.Interfaces;
using Investors.BL.Models;
using Investors.Data.Database;
using Microsoft.EntityFrameworkCore;

namespace Investors.BL.Services;

public class InvestorService(InvestorContext dbContext) : IInvestorService
{
    private readonly InvestorContext dbContext = dbContext;

    public async Task<PagedModel<InvestorModel>> GetAllInvestorsAsync(
        string name, 
        PagedRequest request)
    {
        request = new PagedRequest(request.PageNumber, request.PageSize);

        var query = dbContext.Investor.AsNoTracking()
            .AsQueryable();

        if (!string.IsNullOrEmpty(name))
        {
            query = query.Where(x => x.Name.Contains(name));
        }

        var totalRecords = await query.CountAsync();

        query = query.Include(x => x.Country)
            .Include(x => x.InvestorType)
            .Include(x => x.Commitments);

        var investors = await query.OrderBy(x => x.InvestorID)
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize)
            .Select(x => new InvestorModel
            {
                ID = x.InvestorID,
                Name = x.Name,
                Type = x.InvestorType.TypeOfInvestor,
                DateAdded = x.DateAdded.ToOrdinateDate(),
                Country = x.Country.Name,
                TotalCommitment = x.Commitments
                .Select(x => x.Amount)
                .Sum()
            })
            .ToListAsync();

        var response = new PagedModel<InvestorModel>(
            request.PageNumber, request.PageSize, totalRecords, investors);

        return response;
    }

    public async Task<List<CommitmentSummary>> GetCommitmentSummariesAsync(int investorID)
    {
        var commitments = await dbContext.Commitment
            .AsNoTracking()
            .Include(x => x.AssetClass)
            .Where(x => x.InvestorID == investorID)            
            .GroupBy(x => x.AssetClass.Name)
            .Select(x => new CommitmentSummary 
            {
                Key = x.Key,
                ID = $"{x.First().AssetClassID}",
                Total = x.Sum(x => x.Amount)
            })
            .ToListAsync();

        if (commitments.Count > 0 )
        {
            commitments.Add(new CommitmentSummary { ID = "All", Key = "All", Total = commitments.Sum(x => x.Total) });
        }

        return commitments;
    }

    public async Task<PagedModel<CommitmentModel>> GetInvestorCommitment(
        int investorID, 
        int? assetClassID, 
        PagedRequest request)
    {
        request = new PagedRequest(request.PageNumber, request.PageSize);

        var commitmentsQuery = dbContext.Commitment
            .AsNoTracking()
            .Include(x => x.AssetClass)
            .Where(x => x.InvestorID == investorID)
            .AsQueryable();

        if (assetClassID.HasValue)
        {
            commitmentsQuery = commitmentsQuery.Where(x => x.AssetClassID == assetClassID);
        }

        var totalRecords = await commitmentsQuery.CountAsync();

        var commitments = await commitmentsQuery.OrderBy(x => x.InvestorID)
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize)
            .Select(x => new CommitmentModel
            {
                ID = x.CommitmentID,
                AssetClass = x.AssetClass.Name,
                Currency = x.Currency,
                Amount = x.Amount
            })
            .ToListAsync();

        var response = new PagedModel<CommitmentModel>(
            request.PageNumber, request.PageSize, totalRecords, commitments);

        return response;
    }    
}
