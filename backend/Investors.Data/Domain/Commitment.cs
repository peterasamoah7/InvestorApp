namespace Investors.Data.Domain;

public class Commitment
{
    public int CommitmentID { get; set; }
    public decimal Amount { get; set; }
    public string Currency { get; set; }
    public int? AssetClassID { get; set; }
    public AssetClass AssetClass { get; set; }
    public int InvestorID { get; set; }
    public Investor Investor { get; set; }
}
