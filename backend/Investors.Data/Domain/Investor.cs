namespace Investors.Data.Domain;

public class Investor
{
    public int InvestorID { get; set; }
    public string Name { get; set; }
    public DateTime DateAdded { get; set; }
    public DateTime? DateUpdated { get; set; }
    public int? InvestorTypeID { get; set; }
    public InvestorType InvestorType { get; set; }
    public int? CountryID { get; set; }
    public Country Country { get; set; }
    public List<Commitment> Commitments { get; set; } = [];
}
