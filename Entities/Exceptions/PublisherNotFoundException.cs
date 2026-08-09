namespace Entities.Exceptions;

public sealed class PublisherNotFoundException : NotFoundException
{
    public PublisherNotFoundException(Guid publisherId)
        : base($"The publisher with id: {publisherId} doesn't exist in the database.")
    {
    }
}
