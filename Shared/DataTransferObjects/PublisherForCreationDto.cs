namespace Shared.DataTransferObjects;

public record PublisherForCreationDto(
    string? Name,
    string? City,
    string? Country,
    IEnumerable<BookForCreationDto>? Books);
