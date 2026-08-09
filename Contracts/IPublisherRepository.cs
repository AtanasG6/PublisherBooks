using Entities.Models;

namespace Contracts;

public interface IPublisherRepository
{
    IEnumerable<Publisher> GetAllPublishers(bool trackChanges);
    Publisher? GetPublisher(Guid publisherId, bool trackChanges);
}
