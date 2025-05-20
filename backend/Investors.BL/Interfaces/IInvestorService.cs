using Investors.BL.Models;

namespace Investors.BL.Interfaces;

public interface IInvestorService
{
    Task<PagedModel<InvestorModel>> GetAllInvestorsAsync(string name, PagedRequest request);
    Task<List<CommitmentSummary>> GetCommitmentSummariesAsync(int investorID);
    Task<PagedModel<CommitmentModel>> GetInvestorCommitment(int investorID, int? assetClassID, PagedRequest request);
}
