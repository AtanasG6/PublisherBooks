using Shared.DataTransferObjects;

namespace Service.Contracts;

public interface IPublisherService
{
    IEnumerable<PublisherDto> GetAllPublishers(bool trackChanges);
}
