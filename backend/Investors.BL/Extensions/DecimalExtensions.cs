namespace Investors.BL.Extensions;

public static class DecimalExtensions
{
    public static string ToShortForm(this decimal value)
    {
        return value.ToString();
    }
}
