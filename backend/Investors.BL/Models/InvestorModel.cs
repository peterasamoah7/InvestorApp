namespace Investors.BL.Models;

public class InvestorModel
{
    public int ID { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public string DateAdded { get; set; }
    public string Country { get; set; }
    public decimal TotalCommitment { get; set; }
}
