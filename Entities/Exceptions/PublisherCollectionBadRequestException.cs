namespace Entities.Exceptions;

public sealed class PublisherCollectionBadRequestException : BadRequestException
{
    public PublisherCollectionBadRequestException()
        : base("Publisher collection sent from a client is null.")
    {
    }
}
