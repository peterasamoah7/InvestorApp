namespace Investors.BL.Models;

public class CommitmentModel
{
    public int ID { get; set; }
    public string AssetClass { get; set; }
    public string Currency { get; set; }
    public decimal Amount { get; set; }
}
