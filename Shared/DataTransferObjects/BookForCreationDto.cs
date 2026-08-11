namespace Shared.DataTransferObjects;

public record BookForCreationDto(string? Title, int PageCount, string? Genre, int ReleaseYear);
