namespace Shared.DataTransferObjects;

public record BookDto(Guid Id, string? Title, int PageCount, string? Genre, int ReleaseYear);
