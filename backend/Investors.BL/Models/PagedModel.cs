namespace Investors.BL.Models;

public class PagedModel<T>(
    int pageNumber, 
    int pageSize,
    int totalRecords, 
    List<T> items)
{
    public List<T> Items { get; init; } = items;
    public int PageNumber { get; init; } = pageNumber;
    public int PageSize { get; init; } = pageSize;
    public int TotalRecords { get; init; } = totalRecords;
    public int TotalPages => (int)Math.Ceiling(TotalRecords / (decimal)PageSize);        
    public string FirstPage => $"pageNumber=1&pageSize={PageSize}";
    public string LastPage => $"pageNumber={TotalPages}&pageSize={PageSize}";
    public string NextPage => PageNumber >= 1 && PageNumber < TotalPages ? $"pageNumber={PageNumber + 1}&pageSize={PageSize}" : null;
    public string PreviousPage => PageNumber - 1 >= 1 && PageNumber <= TotalPages ? $"pageNumber={PageNumber - 1}&pageSize={PageSize}" : null;
}

public class PagedRequest
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }

    public PagedRequest()
    {
        PageNumber = 1;
        PageSize = 10;
    }

    public PagedRequest(int pageNumber, int pageSize)
    {
        PageNumber = pageNumber < 1 ? 1 : pageNumber;
        PageSize = pageSize > 10 ? 10 : pageSize;
    }
}