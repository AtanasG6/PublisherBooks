namespace Shared.DataTransferObjects;

public record BookDto
{
    public Guid Id { get; init; }
    public string? Title { get; init; }
    public int PageCount { get; init; }
    public string? Genre { get; init; }
    public int ReleaseYear { get; init; }
}
