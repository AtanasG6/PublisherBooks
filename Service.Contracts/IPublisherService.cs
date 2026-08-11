using Shared.DataTransferObjects;

namespace Service.Contracts;

public interface IPublisherService
{
    IEnumerable<PublisherDto> GetAllPublishers(bool trackChanges);
    PublisherDto GetPublisher(Guid publisherId, bool trackChanges);
    PublisherDto CreatePublisher(PublisherForCreationDto publisher);
    IEnumerable<PublisherDto> GetByIds(IEnumerable<Guid> ids, bool trackChanges);
    (IEnumerable<PublisherDto> publishers, string ids) CreatePublisherCollection(
        IEnumerable<PublisherForCreationDto>? publisherCollection);
    void DeletePublisher(Guid publisherId, bool trackChanges);
}
