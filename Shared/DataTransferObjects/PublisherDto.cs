namespace Shared.DataTransferObjects;

public record PublisherDto
{
    public Guid Id { get; init; }
    public string? Name { get; init; }
    public string? Location { get; init; }
}
