namespace Domain.Filters;

public class InstructorFilter
{
    public string? Name { get; set; } = string.Empty;
    public string? Phone { get; set; } = string.Empty;
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}