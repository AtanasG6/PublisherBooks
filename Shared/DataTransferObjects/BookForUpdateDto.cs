namespace Shared.DataTransferObjects;

public record BookForUpdateDto(string? Title, int PageCount, string? Genre, int ReleaseYear);
