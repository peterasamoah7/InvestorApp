namespace Investors.BL.Extensions;

public static class DateTimeExtensions
{
    public static string ToOrdinateDate(this DateTime date)
    {
        int day = date.Day;
        string month = date.ToString("MMM");
        string year = date.ToString("yyyy");

        string suffix = GetDateSuffix(day);

        return string.Format("{0} {1}{2}, {3}", month, day, suffix, year);
    }

    private static string GetDateSuffix(int day)
    {
        if (day >= 11 && day <= 13) 
            return "th";

        if (day % 10 == 1) return "st";
        if (day % 10 == 2) return "nd";
        if (day % 10 == 3) return "rd";

        return "th";
    }
}
